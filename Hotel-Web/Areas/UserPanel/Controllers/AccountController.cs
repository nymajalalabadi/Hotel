using Hotel_Application.Extensions;
using Hotel_Application.Services.Interface;
using Hotel_Domain.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Areas.UserPanel.Controllers
{
    public class AccountController : UserPanelBaseController
    {
        #region constractor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> EditUserProfile()
        {
            var user = await _userService.GetUserProfileForEdit(User.GetUserId());

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserProfileViewModel editUser)
        {
            if (!ModelState.IsValid)
            {
                return View(editUser);
            }

            var result = await _userService.EditUserProfile(editUser);

            switch (result)
            {
                case EditUserProfileResult.NotFound:
                    TempData[WarningMessage] = "کاربری با مشخصات وارد شده یافت نشد";
                    break;

                case EditUserProfileResult.Success:
                    TempData[SuccessMessage] = "عملیات ویرایش حساب کاربری با موفقیت انجام شد";

                    return RedirectToAction("Index", "Home");
            }

            return View(editUser);
        }
    }
}
