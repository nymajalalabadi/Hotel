using Hotel_Application.Extensions;
using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Hotels;
using Hotel_Domain.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hotel_Web.Controllers
{
    public class HotelController : BaseController
    {
        #region constractor

        private readonly IHotelService _hotelService;
        private readonly IOrderService _orderService;

        public HotelController(IHotelService hotelService, IOrderService orderService)
        {
            _hotelService = hotelService;
            _orderService = orderService;
        }

        #endregion


        #region Show All Hotel ShowSingleHotel

        [HttpGet]
        public async Task<IActionResult> ShowAllHotels(FilterHotelViewModel filter)
        {
            var result = await _hotelService.GetAllHotelForShow(filter);

            return View(result);
        }

        #endregion

        #region Show Single Hotel

        [HttpGet]
        public async Task<IActionResult> ShowSingleHotel(long id)
        {
            ViewData["HotelRooms"] = await _hotelService.GetHotelRoomsByHotelId(id);

            var result = await _hotelService.GetDetailsHotel(id);

            return View(result);
        }

        #endregion

        #region Reserve Room

        [HttpGet]
        public async Task<IActionResult> ReserveRoom(long roomId)
        {
            var result = await _hotelService.GetSingleRoomById(roomId);

            return View(result);
        }

        #endregion

        #region Create Order

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel create)
        {
            create.UserId = User.GetUserId();

            long orderId = await _orderService.CreateOrder(create);

            return Redirect("/UserPanel/Basket/" + orderId);
        }

        #endregion

    }
}
