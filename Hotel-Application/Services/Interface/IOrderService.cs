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

        Task<BasketViewModel> GetUserBasket(long userId);

        Task<bool> RemoveOrderDetailFromOrder(long detailId);

        Task<CheckoutViewModel> GetUserCheckout(long userId);

        #endregion
    }
}
