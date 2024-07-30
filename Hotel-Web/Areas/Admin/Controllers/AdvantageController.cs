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

        #endregion
    }
}
