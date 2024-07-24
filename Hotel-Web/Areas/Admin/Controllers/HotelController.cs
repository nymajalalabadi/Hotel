using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Hotels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Areas.Admin.Controllers
{
    public class HotelController : AdminBaseController
    {
        #region constractor

        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        #endregion

        #region Actions

        #region Hotel

        public async Task<IActionResult> FilterHotels(FilterHotelViewModel filterHotel)
        {
            var result = await _hotelService.FilterHotel(filterHotel);

            return View(result);
        }

        #endregion

        #endregion
    }
}
