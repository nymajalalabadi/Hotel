using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Baner;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Areas.Admin.Controllers
{
    public class BanerController : AdminBaseController
    {
        #region constractor

        private readonly IBanerService _banerService;

        public BanerController(IBanerService banerService)
        {
            _banerService = banerService;
        }

        #endregion

        #region Action

        public async Task<IActionResult> Index(FilterBanerViewModel filter)
        {
            var result = await _banerService.FilterBaner(filter);

            return View(result);
        }

        #endregion
    }
}
