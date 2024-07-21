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

        #region Edit Baner

        [HttpGet]
        public async Task<IActionResult> EditBaner(long banerId)
        {
            var baner = await _banerService.GetEditBaner(banerId);

            if (baner == null)
            {
                return NotFound();
            }

            return View(baner);
        }

        [HttpPost]
        public async Task<IActionResult> EditBaner(EditBanerViewModel editBaner)
        {
            if (!ModelState.IsValid)
            {
                return View(editBaner);
            }

            var result = await _banerService.EditBaner(editBaner);

            switch (result)
            {
                case EditBanerResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("index");

                case EditBanerResult.Failure:
                    TempData[SuccessMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(editBaner);
        }

        #endregion

        #region Delete Baner

        [HttpGet]
        public async Task<IActionResult> DeleteBaner(long banerId)
        {
            var result = await _banerService.DeleteBaner(banerId);

            if (result)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[SuccessMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("index");
        }

        #endregion

        #endregion
    }
}
