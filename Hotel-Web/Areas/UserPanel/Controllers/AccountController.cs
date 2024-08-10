using Hotel_Application.Extensions;
using Hotel_Application.Services.Interface;
using Hotel_Domain.Entities.Orders;
using Hotel_Domain.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Areas.UserPanel.Controllers
{
    public class AccountController : UserPanelBaseController
    {
        #region constractor

        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public AccountController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        #endregion

        #region Edit User Profile

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

        #endregion

        #region Change Password

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ChangePassword(User.GetUserId(), changePassword);

                switch (result)
                {
                    case ChangePasswordResult.NotFound:
                        TempData[WarningMessage] = "کاربری با مشخصات وارد شده یافت نشد";
                        break;

                    case ChangePasswordResult.Failed:
                        TempData[ErrorMessage] = "لطفا رمز عبور قبلی خود را درست وارد بفرمایید";
                        break;

                    case ChangePasswordResult.PasswordEqual:
                        TempData[InfoMessage] = "لطفا از کلمه عبور جدیدی استفاده کنید";
                        ModelState.AddModelError("NewPassword", "لطفا از کلمه عبور جدیدی استفاده کنید");
                        break;

                    case ChangePasswordResult.Success:
                        TempData[SuccessMessage] = "کلمه ی عبور شما با موفقیت تغیر یافت";
                        TempData[InfoMessage] = "لطفا جهت تکمیل فراید تغیر کلمه ی عبور ،مجددا وارد سایت شود";

                        await HttpContext.SignOutAsync();

                        return RedirectToAction("Login", "Account", new { area = "" });
                }
            }
            return View(changePassword);
        }

        #endregion

        #region Basket

        [HttpGet("Basket/{orderId}")]
        public async Task<IActionResult> UserBasket(long orderId)
        {
            var userId = User.GetUserId();

            var basket = await _orderService.GetUserBasket(userId);

            return View(basket);
        }

        #endregion

        #region Remove Order Detail

        public async Task<IActionResult> RemoveOrderDetail(long orderDetailId)
        {
            var result = await _orderService.RemoveOrderDetailFromOrder(orderDetailId);

            if (result)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[ErrorMessage] = "عملیات با شکست انجام شد";
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Checkout

        public async Task<IActionResult> Checkout()
        {
            var userId = User.GetUserId();

            var viewModel = await _orderService.GetUserCheckout(userId);

            if (viewModel != null)
            {
                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}
