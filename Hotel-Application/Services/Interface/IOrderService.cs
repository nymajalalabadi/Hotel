using Hotel_Domain.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Services.Interface
{
    public interface IOrderService
    {
        #region Methods

        Task<long> CreateOrder(CreateOrderViewModel create);

        Task<BasketViewModel> GetUserBasket(long userId, long orderId);

        Task<bool> RemoveOrderDetailFromOrder(long detailId);

        Task<CheckoutViewModel> GetUserCheckout(long userId, long orderId);

        Task<CheckoutResult> Checkout(long userId, CheckoutViewModel checkout);

        Task<List<UserOrdersViewModel>> GetUserOrders(long userId); 

        #endregion
    }
}
