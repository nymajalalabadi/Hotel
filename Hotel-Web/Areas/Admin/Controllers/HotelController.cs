using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Baner;
using Hotel_Domain.ViewModels.HotelGalleries;
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

        #region Delete Hotel

        public async Task<IActionResult> DeleteHotel(long Id)
        {
            var result = await _hotelService.DeleteHotel(Id);

            if (result == true)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[SuccessMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("FilterHotels");
        }

        #endregion

        #endregion

        #region Hotel Gallery

        #region Filter Hotel Gallery

        public async Task<IActionResult> FilterHotelGallery(int id, FilterHotelGalleriesViewHtml filter)
        {
            ViewBag.Hotel = await _hotelService.GetHotelById(id);

            filter.HotelId = id;

            var result = await _hotelService.FilterHotelGalleries(filter);

            return View(result);
        }

        #endregion

        #region create Hotel Gallery

        [HttpGet]
        public async Task<IActionResult> CreateHotelGallery(int id)
        {
            var model = new CreateHotelGalleryViewHtml()
            {
                HotelId = id,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotelGallery(CreateHotelGalleryViewHtml create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _hotelService.CreateHotelGallery(create);

            switch (result)
            {
                case CreateHoteGallerylResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterHotels");

                case CreateHoteGallerylResult.Failure:
                    TempData[SuccessMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(create);
        }

        #endregion

        #region edit Hotel Gallery

        #endregion

        #region delete Hotel Gallery

        #endregion

        #endregion

        #endregion
    }
}
