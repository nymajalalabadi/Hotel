using Hotel_Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.InterFaces
{
    public interface IOrderRepository
    {
        #region Methods

        Task<Order?> CheckUserOrder(long userId);

        Task<OrderDetail?> CheckOrderDetail(long orderId, long hotelRoomId);

        Task<OrderDetail?> GetOrderDetailByRoomId(long hotelRoomId);

        Task<OrderReserveDate?> GetOrderReserveDateByReserveId(long ReserveId);

        Task<List<Order>> GetOrdersById(long userId);

        Task<Order?> GetOrderById(long OrderId);

        Task<Order?> GetOrderByUserId(long userId);

        Task<Order?> GetOrderByOrderIdUserId(long userId, long orderId);

        Task<Order?> GetOrderById(long OrderId, long userId);

        Task<int> OrderSum(long OrderId);

        Task AddOrder(Order order);

        Task OrderReserveDateRange(List<OrderReserveDate> orderReserveDates);

        Task AddOrderDetail(OrderDetail orderDetail);

        void UpdateOrderReserveDate(OrderReserveDate orderReserveDate);

        Task SaveChanges();

        void UpdateOrder(Order order);

        void UpdateOrderDetail(OrderDetail orderDetail);

        Task<Order?> GetBasketForUser(long orderId, long userId);

        Task<Order?> GetBasketForUser(long userId);

        Task<OrderDetail?> GetOrderDetailById(long detailId);

        Task<Order?> GetOrderDetail(long orderId);

        #endregion
    }
}
