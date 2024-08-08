using Hotel_Application.Services.Interface;
using Hotel_Domain.Entities.Account;
using Hotel_Domain.Entities.Orders;
using Hotel_Domain.Entities.Reserve;
using Hotel_Domain.InterFaces;
using Hotel_Domain.ViewModels.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel_Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        #region Constructor

        private readonly IOrderRepository _orderRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IReserveDateRepository _reserveDateRepository;

        public OrderService(IOrderRepository orderRepository, IHotelRepository hotelRepository, IReserveDateRepository reserveDateRepository)
        {
            _orderRepository = orderRepository;
            _hotelRepository = hotelRepository;
            _reserveDateRepository = reserveDateRepository;
        }

        #endregion

        #region Methods

        public async Task<long> CreateOrder(CreateOrderViewModel create)
        {
            var room = await _hotelRepository.GetHotelRoomById(create.RoomId);

            var order = await _orderRepository.GetOrderById(create.UserId);

            if (order == null)
            {
                order = new Order()
                {
                    HotelId = room!.HotelId,
                    UserId = create.UserId
                };

                await _orderRepository.AddOrder(order);
                await _orderRepository.SaveChanges();

                var detail = new OrderDetail()
                {
                    HotelRoomId = room.Id,
                    OrderId = order.Id
                };

                await _orderRepository.AddOrderDetail(detail);
                await _orderRepository.SaveChanges();

                var reserveDates = new List<OrderReserveDate>();

                foreach (var reserveDateId in create.ReserveDateId)
                {
                    var reserve = await _reserveDateRepository.GetReserDateByRoomId(reserveDateId, room.Id);

                    if (reserve != null)
                    {
                        reserve.Count -= 1;

                        reserveDates.Add(new OrderReserveDate()
                        {
                            OrderDetailId = detail.Id,
                            ReserveDateId = reserve.Id,
                            Price = reserve.Price,
                            Count = 1
                        });

                         _reserveDateRepository.UpdateReserveDate(reserve);
                    }
                }

                await _orderRepository.OrderReserveDateRange(reserveDates);
                await _orderRepository.SaveChanges();

                detail.Price = reserveDates.Sum(x => x.Price);
                order.OrderSum = detail.Price;

                _orderRepository.UpdateOrderDetail(detail);
                _orderRepository.UpdateOrder(order);

                await _orderRepository.SaveChanges();
            }
            else
            {
                var detail = await _orderRepository.GetOrderDetailByRoomId(create.RoomId);

                if (detail != null)
                {
                    var reserveDates = new List<OrderReserveDate>();

                    foreach (var reserveDateId in create.ReserveDateId)
                    {
                        var reserve = await _reserveDateRepository.GetReserDateByRoomId(reserveDateId, room.Id);

                        if (reserve != null)
                        {
                            var orderReserveDate = await _orderRepository.GetOrderReserveDateByReserveId(reserve.Id);

                            if (orderReserveDate != null)
                            {
                                if (reserve.Count != 0)
                                {
                                    reserve.Count -= 1;

                                    _reserveDateRepository.UpdateReserveDate(reserve);

                                    detail.Price += reserve.Price;
                                    order.OrderSum += reserve.Price;
                                    
                                    _orderRepository.UpdateOrderDetail(detail);
                                    _orderRepository.UpdateOrder(order);

                                    orderReserveDate!.Count += 1;
                                    orderReserveDate.Price *= 2;

                                    _orderRepository.UpdateOrderReserveDate(orderReserveDate);

                                    await _orderRepository.SaveChanges();
                                }
                            }
                            else
                            {
                                reserve.Count -= 1;
                                _reserveDateRepository.UpdateReserveDate(reserve);

                                reserveDates.Add(new OrderReserveDate()
                                {
                                    OrderDetailId = detail.Id,
                                    ReserveDateId = reserve.Id,
                                    Price = reserve.Price,
                                    Count = 1
                                });

                                detail.Price += reserve.Price;
                                order.OrderSum += reserve.Price;
                                
                                _orderRepository.UpdateOrderDetail(detail);
                                _orderRepository.UpdateOrder(order);

                                await _orderRepository.SaveChanges();
                            }
                        }
                    }

                    await _orderRepository.OrderReserveDateRange(reserveDates);
                    await _orderRepository.SaveChanges();
                }
                else
                {
                    var orderDetail = new OrderDetail()
                    {
                        HotelRoomId = room!.Id,
                        OrderId = order.Id
                    };

                    await _orderRepository.AddOrderDetail(orderDetail);
                    await _orderRepository.SaveChanges();

                    var reserveDates = new List<OrderReserveDate>();

                    foreach (var reserveDateId in create.ReserveDateId)
                    {
                        var reserve = await _reserveDateRepository.GetReserDateByRoomId(reserveDateId, room.Id);

                        if (reserve != null)
                        {
                            reserve.Count -= 1;
                            _reserveDateRepository.UpdateReserveDate(reserve);

                            reserveDates.Add(new OrderReserveDate()
                            {
                                OrderDetailId = orderDetail.Id,
                                ReserveDateId = reserve.Id,
                                Price = reserve.Price,
                                Count = 1
                            });

                        }
                    }

                    await _orderRepository.OrderReserveDateRange(reserveDates);
                    await _orderRepository.SaveChanges();


                    orderDetail.Price = reserveDates.Sum(x => x.Price);
                    order.OrderSum += orderDetail.Price;

                    _orderRepository.UpdateOrderDetail(orderDetail);
                    _orderRepository.UpdateOrder(order);

                    await _orderRepository.SaveChanges();
                }
            }

            return order.Id;
        }

        public async Task<BasketViewModel> GetUserBasket(long userId)
        {
            var order = await _orderRepository.GetOrderByUserId(userId);

            if (order == null)
            {
                return null;
            }

            return new BasketViewModel()
            {
                OrderSum = order.OrderSum,

                BasketDetailViewModels = order.OrderDetails.Select(b => new BasketDetailViewModel()
                {
                    DetailId = b.Id,
                    BasePrice = b.HotelRoom.RoomPrice,
                    HotelName = b.HotelRoom.Hotel.Title,
                    RoomName = b.HotelRoom.Title,
                    TotalPrice = b.Price,
                    ReserveDates = b.OrderReserveDates.Select(r => new ReserveDate()
                    {
                        Id = r.ReserveDate.Id,
                        Price = r.ReserveDate.Price,
                        ReserveTime = r.ReserveDate.ReserveTime,
                    }).ToList(),
                }).ToList()

            };
        }

        #endregion
    }
}
