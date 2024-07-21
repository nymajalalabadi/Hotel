using Hotel_Application.Services.Interface;
using Hotel_Domain.Entities.Baner;
using Hotel_Domain.ViewModels.Baner;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        #region List Baner

        public async Task<IActionResult> Index(FilterBanerViewModel filter)
        {
            var result = await _banerService.FilterBaner(filter);

            return View(result);
        }

        #endregion

        #region Create Baner

        [HttpGet]
        public IActionResult CreateBaner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBaner(CreateBanerViewModel createBaner)
        {
            if (!ModelState.IsValid)
            {
                return View(createBaner);
            }

            var result = await _banerService.CreateBanerViewModel(createBaner);

            switch (result)
            {
                case CreateBanerResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("index");

                case CreateBanerResult.Failure:
                    TempData[SuccessMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(createBaner);
        }

        #endregion

        #endregion
    }
}
