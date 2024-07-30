using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Advantage;
using Hotel_Domain.ViewModels.Hotels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Areas.Admin.Controllers
{
    public class AdvantageController : AdminBaseController
    {
        #region constractor

        private readonly IAdvantageService _advantageService;

        public AdvantageController(IAdvantageService advantageService)
        {
            _advantageService = advantageService;
        }

        #endregion

        #region Actions

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

        #endregion
    }
}
