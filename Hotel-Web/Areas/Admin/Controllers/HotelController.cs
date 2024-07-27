using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Baner;
using Hotel_Domain.ViewModels.HotelGalleries;
using Hotel_Domain.ViewModels.HotelRooms;
using Hotel_Domain.ViewModels.HotelRules;
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
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
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
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;

                case EditHotelResult.HasNotFound:
                    TempData[WarningMessage] = "هتل مورد نظر پیدا نشد";
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
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("FilterHotels");
        }

        #endregion

        #endregion

        #region Hotel Gallery

        #region Filter Hotel Gallery

        public async Task<IActionResult> FilterHotelGallery(long id, FilterHotelGalleriesViewHtml filter)
        {
            ViewBag.Hotel = await _hotelService.GetHotelById(id);

            filter.HotelId = id;

            var result = await _hotelService.FilterHotelGalleries(filter);

            return View(result);
        }

        #endregion

        #region create Hotel Gallery

        [HttpGet]
        public async Task<IActionResult> CreateHotelGallery(long id)
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
                case CreateHotelGalleryResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterHotels");

                case CreateHotelGalleryResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(create);
        }

        #endregion

        #region edit Hotel Gallery

        [HttpGet]
        public async Task<IActionResult> EditHotelGallery(long id)
        {
            var model = await _hotelService.GetHotelGalleryForEdit(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditHotelGallery(EditHotelGalleryViewHtml edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _hotelService.EditHotelGallery(edit);

            switch (result)
            {
                case EditHotelGalleryResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterHotels");

                case EditHotelGalleryResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
                case EditHotelGalleryResult.HasNotFound:
                    TempData[WarningMessage] = "هتل مورد نظر یافت نشد";
                    break;
            }

            return View(edit);
        }

        #endregion

        #region delete Hotel Gallery

        public async Task<IActionResult> DeleteHotelGallery(long Id)
        {
            var result = await _hotelService.DeleteHotelGallery(Id);

            if (result == true)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("FilterHotels");
        }

        #endregion

        #endregion

        #region Hotel Rule

        #region Filter Hotel Rule

        public async Task<IActionResult> FilterHotelRules(long id, FilterHotelRulesViewModel filter)
        {
            ViewBag.Hotel = await _hotelService.GetHotelById(id);

            filter.HotelId = id;

            var result = await _hotelService.FilterHotelRules(filter);

            return View(result);
        }

        #endregion

        #region create Hotel Rule

        [HttpGet]
        public async Task<IActionResult> CreateHotelRule(long id)
        {
            var model = new CreateHotelRuleViewModel()
            {
                HotelId = id,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotelRule(CreateHotelRuleViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _hotelService.CreateHotelRule(create);

            switch (result)
            {
                case CreateHotelRuleResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterHotels");

                case CreateHotelRuleResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(create);
        }

        #endregion

        #region edit Hotel Rule

        [HttpGet]
        public async Task<IActionResult> EditHotelRule(long id)
        {
            var model = await _hotelService.GetHotelRuleForEdit(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditHotelRule(EditHotelRuleViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _hotelService.EditHotelRule(edit);

            switch (result)
            {
                case EditHotelRuleResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterHotels");

                case EditHotelRuleResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
                case EditHotelRuleResult.HasNotFound:
                    TempData[WarningMessage] = "هتل مورد نظر یافت نشد";
                    break;
            }

            return View(edit);
        }

        #endregion

        #region delete Hotel Rule

        public async Task<IActionResult> DeleteHotelRule(long Id)
        {
            var result = await _hotelService.DeleteHotelRule(Id);

            if (result == true)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("FilterHotels");
        }

        #endregion

        #endregion

        #region Hotel room

        #region Filter Hotel Room

        public async Task<IActionResult> FilterHotelRooms(long id, FilterHotelRoomsViewModel filter)
        {
            ViewBag.Hotel = await _hotelService.GetHotelById(id);

            filter.HotelId = id;

            var result = await _hotelService.FilterHotelRooms(filter);

            return View(result);
        }

        #endregion

        #region create Hotel Room

        [HttpGet]
        public async Task<IActionResult> CreateHotelRoom(long id)
        {
            var model = new CreateHotelRoomViewModel()
            {
                HotelId = id,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotelRoom(CreateHotelRoomViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _hotelService.CreateHotelRoom(create);

            switch (result)
            {
                case CreateHotelRoomResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterHotels");

                case CreateHotelRoomResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(create);
        }

        #endregion

        #region edit Hotel Room

        [HttpGet]
        public async Task<IActionResult> EditHotelRoom(long id)
        {
            var model = await _hotelService.GetHotelRoomForEdit(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditHotelRoom(EditHotelRoomViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _hotelService.EditHotelRoom(edit);

            switch (result)
            {
                case EditHotelRoomResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterHotels");

                case EditHotelRoomResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
                case EditHotelRoomResult.HasNotFound:
                    TempData[WarningMessage] = "هتل مورد نظر یافت نشد";
                    break;
            }

            return View(edit);
        }

        #endregion

        #region delete Hotel Room

        public async Task<IActionResult> DeleteHotelRoom(long Id)
        {
            var result = await _hotelService.DeleteHotelRoom(Id);

            if (result == true)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("FilterHotels");
        }

        #endregion

        #endregion

        #endregion
    }
}
