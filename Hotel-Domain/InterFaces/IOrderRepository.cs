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

        Task<Order?> GetOrderById(long OrderId);

        Task<Order?> GetOrderById(long OrderId, long userId);

        Task<int> OrderSum(long OrderId);

        Task AddOrder(Order order);

        Task AddOrderDetail(OrderDetail orderDetail);

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
