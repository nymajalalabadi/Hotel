using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Baner;
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

        #region Filter Hotels

        public async Task<IActionResult> FilterHotels(FilterHotelViewModel filterHotel)
        {
            var result = await _hotelService.FilterHotel(filterHotel);

            return View(result);
        }

        #endregion

        #region Create Hotel

        [HttpGet]
        public async Task<IActionResult> CreateHotel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel(CreateHotelViewModel createHotel)
        {
            if (!ModelState.IsValid)
            {
                return View(createHotel);
            }

            var result = await _hotelService.CreateHotel(createHotel);

            switch (result)
            {
                case CreateHotelResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterHotels");

                case CreateHotelResult.Failure:
                    TempData[SuccessMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(createHotel);
        }

        #endregion

        #region Edit Hotel

        [HttpGet]
        public async Task<IActionResult> EditHotel(long Id)
        {
            var hotel = await _hotelService.GetHotelForEdit(Id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> EditHotel(EditHotelViewModel editHotel)
        {
            if (!ModelState.IsValid)
            {
                return View(editHotel);
            }

            var result = await _hotelService.EditHotel(editHotel);

            switch (result)
            {
                case EditHotelResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterHotels");

                case EditHotelResult.Failure:
                    TempData[SuccessMessage] = "عملیات با شکست مواجه شد";
                    break;

                case EditHotelResult.HasNotFound:
                    TempData[SuccessMessage] = "هتل مورد نظر پیدا نشد";
                    break;
            }

            return View(editHotel);
        }

        #endregion

        #endregion

        #endregion
    }
}
