using Hotel_Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Constructor

        private readonly IBanerService _banerService;

        public HomeController(IBanerService banerService)
        {
            _banerService = banerService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            ViewData["baner"] = await _banerService.GetDetailsBaners();

            return View();
        }
    }
}