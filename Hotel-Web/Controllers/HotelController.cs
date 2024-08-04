using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Hotels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Controllers
{
    public class HotelController : BaseController
    {
        #region constractor

        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
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
    }
}
