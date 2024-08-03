using Hotel_Application.Services.Implementation;
using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Advantage;
using Hotel_Domain.ViewModels.Hotels;
using Hotel_Domain.ViewModels.Reserve;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Areas.Admin.Controllers
{
    public class AdvantageController : AdminBaseController
    {
        #region constractor

        private readonly IAdvantageService _advantageService;

        private readonly IHotelService _hotelService;

        private readonly IReserveDateService _reserveDateService;

        public AdvantageController(IAdvantageService advantageService, IHotelService hotelService, IReserveDateService reserveDateService)
        {
            _advantageService = advantageService;
            _hotelService = hotelService;
            _reserveDateService = reserveDateService;
        }

        #endregion

        #region Actions

        #region Advantage

        #region Filter Advantage

        public async Task<IActionResult> FilterAdvantages(FilterAdvantageRoomViewModel filter)
        {
            var result = await _advantageService.FilterAdvantageRooms(filter);

            return View(result);
        }

        #endregion

        #region Create Advantage

        [HttpGet]
        public async Task<IActionResult> CreateAdvantage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvantage(CreateAdvantageRoomViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _advantageService.CreateAdvantageRoom(create);

            switch (result)
            {
                case CreateAdvantageRoomResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterAdvantages");

                case CreateAdvantageRoomResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(create);
        }

        #endregion

        #region Edit Advantage

        [HttpGet]
        public async Task<IActionResult> EditAdvantage(long id)
        {
            var model = await _advantageService.GetAdvantageRoomForEdit(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAdvantage(EditAdvantageRoomViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _advantageService.EditAdvantageRoom(edit);

            switch (result)
            {
                case EditAdvantageRoomResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterAdvantages");

                case EditAdvantageRoomResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;

                case EditAdvantageRoomResult.HasNotFound:
                    TempData[ErrorMessage] = "پیدا نشد";
                    break;
            }

            return View(edit);
        }

        #endregion

        #region Delete Advantage

        public async Task<IActionResult> DeleteAdvantage(long Id)
        {
            var result = await _advantageService.DeleteAdvantageRoom(Id);

            if (result == true)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("FilterAdvantages");
        }

        #endregion

        #region Selected Room To Advatange

        [HttpGet]
        public async Task<IActionResult> ShowRoomToAdvantage(long id, FilterSelectedRoomToAdvantageViewModel filter)
        {
            filter.RoomId = id;

            var result = await _advantageService.FilterSelectedRoomToAdvantage(filter);

            ViewBag.room = await _hotelService.GetHotelRoomById(id);

            return View(result);
        }

        #endregion

        #region Create Or Edit Room To Advantage

        [HttpGet]
        public async Task<IActionResult> CreateOrEditRoomToAdvantage(long id)
        {
            ViewData["Advantages"] = await _advantageService.GetAllAdvantageRooms();

            var model = await _advantageService.GetSelectedRoomToAdvantage(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEditRoomToAdvantage(EditOrCreateSelectedRoomToAdvantageViewModel editOrCreate)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Advantages"] = await _advantageService.GetAllAdvantageRooms();
                return View(editOrCreate);
            }

            var result = await _advantageService.CreateOrEditSelectedRoomToAdvantage(editOrCreate);

            switch (result)
            {
                case EditOrCreateSelectedRoomToAdvantageResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterHotels", "Hotel");

                case EditOrCreateSelectedRoomToAdvantageResult.NotExistAdvantage:
                    TempData[ErrorMessage] = "لطفا ویژگی های مورد نظر را انتخاب کنید";
                    break;

                case EditOrCreateSelectedRoomToAdvantageResult.HasNotFound:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            ViewData["Advantages"] = await _advantageService.GetAllAdvantageRooms();

            return View(editOrCreate);
        }

        #endregion

        #endregion

        #region Reserve Date

        #region Filter Reserve Date

        [HttpGet]
        public async Task<IActionResult> FilterReserveDates(long id, FilterReserveDateViewModel filter)
        {
            filter.RoomId = id;

            var result = await _reserveDateService.FilterReserveDate(filter);

            return View(result);
        }

        #endregion

        #region Create Reserve Date

        [HttpGet]
        public async Task<IActionResult> CreateReserveDate(long id)
        {
            var model = await _reserveDateService.GetReserveDateForCreate(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReserveDate(CreateReserveDateViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _reserveDateService.CreateReserveDate(create);

            switch (result)
            {
                case CreateReserveDateResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterReserveDates", new { id = create.RoomId });

                case CreateReserveDateResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;

                case CreateReserveDateResult.IsExit:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;

            }

            return View(create); 
        }

        #endregion

        #region Edit Reserve Date

        [HttpGet]
        public async Task<IActionResult> EditReserveDate(long id)
        {
            var model = await _reserveDateService.GetReserveDateForEdit(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditReserveDate(EditReserveDateViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _reserveDateService.EditReserveDate(edit);

            switch (result)
            {
                case EditReserveDateResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterReserveDates", new { id = edit.RoomId });

                case EditReserveDateResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;

                case EditReserveDateResult.HasNotFound:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;

            }

            return View(edit);
        }

        #endregion

        #endregion

        #endregion
    }
}
