using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Advantage;
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

        #endregion
    }
}
