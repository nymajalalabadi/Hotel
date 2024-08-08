using Hotel_DataLayer.Context;
using Hotel_Domain.Entities.Orders;
using Hotel_Domain.Entities.Reserve;
using Hotel_Domain.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        #region Constructor

        private readonly HotelContext _context;

        public OrderRepository(HotelContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<Order?> CheckUserOrder(long userId)
        {
            return await _context.Orders.AsQueryable()
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.UserId == userId && !o.IsFinilly);
        }

        public async Task<OrderDetail?> CheckOrderDetail(long orderId, long hotelRoomId)
        {
            return await _context.OrderDetails.AsQueryable()
                .Where(c => c.OrderId == orderId && c.HotelRoomId == hotelRoomId && !c.IsDelete)
                .FirstOrDefaultAsync();
        }

        public async Task<OrderDetail?> GetOrderDetailByRoomId(long hotelRoomId)
        {
            return await _context.OrderDetails.FirstOrDefaultAsync(o => o.HotelRoomId.Equals(hotelRoomId));
        }

        public async Task<OrderReserveDate?> GetOrderReserveDateByReserveId(long ReserveId)
        {
            return await _context.OrderReserveDates.FirstOrDefaultAsync(o => o.ReserveDateId == ReserveId);
        }

        public async Task<Order?> GetOrderById(long OrderId)
        {
            return await _context.Orders
                .AsQueryable()
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.OrderReserveDates)
                .SingleOrDefaultAsync(o => o.Id == OrderId && !o.IsFinilly);
        }

        public async Task<Order?> GetOrderByUserId(long userId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(o => o.OrderReserveDates).ThenInclude(o => o.ReserveDate)
                .Include(o => o.OrderDetails).ThenInclude(o => o.HotelRoom).ThenInclude(o => o.Hotel)
                    .SingleOrDefaultAsync(o => o.UserId == userId && !o.IsFinilly);
        }

        public async Task<Order?> GetOrderById(long OrderId, long userId)
        {
            return await _context.Orders
                .AsQueryable()
                .SingleOrDefaultAsync(o => o.Id == OrderId && o.UserId == userId);
        }

        public async Task<int> OrderSum(long OrderId)
        {
            return await _context.OrderDetails.AsQueryable()
                .Include(o => o.OrderReserveDates)
               .Where(c => c.OrderId == OrderId && !c.IsDelete)
               .SumAsync(c => c.Price * c.OrderReserveDates.Count);
        }

        public async Task AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task OrderReserveDateRange(List<OrderReserveDate> orderReserveDates)
        {
            foreach (var reserveDate in orderReserveDates)
            {
                await _context.OrderReserveDates.AddRangeAsync(reserveDate);
            }
        }

        public async Task AddOrderDetail(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
        }

        public void UpdateOrderReserveDate(OrderReserveDate orderReserveDate)
        {
            _context.OrderReserveDates.Update(orderReserveDate);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
        }

        public async Task<Order?> GetBasketForUser(long orderId, long userId)
        {
            return await _context.Orders.AsQueryable()
               .Include(o => o.User)
               .Include(o => o.OrderDetails).ThenInclude(d => d.HotelRoom)
               .Where(o => o.Id == orderId && o.UserId == userId)
               .Select(o => new Order()
               {
                   UserId = o.UserId,
                   CreateDate = o.CreateDate,
                   Id = o.Id,
                   IsDelete = o.IsDelete,
                   IsFinilly = o.IsFinilly,
                   OrderSum = o.OrderSum,
                   OrderDetails = o.OrderDetails.Where(d => d.OrderId == orderId && !d.IsDelete && !d.Order.IsFinilly).ToList()
               })
               .FirstOrDefaultAsync();
        }

        public async Task<Order?> GetBasketForUser(long userId)
        {
            return await _context.Orders
                .Include(c => c.OrderDetails).ThenInclude(c => c.HotelRoom)
               .Where(c => c.UserId == userId && c.OrderState == OrderState.Processing && !c.IsFinilly && !c.IsDelete)
               .FirstOrDefaultAsync();
        }

        public async Task<OrderDetail?> GetOrderDetailById(long detailId)
        {
            return await _context.OrderDetails.AsQueryable()
                .Include(o => o.OrderReserveDates)
                .SingleOrDefaultAsync(d => d.Id == detailId);
        }

        public async Task<Order?> GetOrderDetail(long orderId)
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails).ThenInclude(d => d.HotelRoom)
                .Where(o => o.Id == orderId)
                .FirstOrDefaultAsync();
        }

        #endregion
    }
}
