using Hotel_Application.Extensions;
using Hotel_Application.Services.Interface;
using Hotel_Domain.Entities.Orders;
using Hotel_Domain.ViewModels.Account;
using Hotel_Domain.ViewModels.Order;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

            var basket = await _orderService.GetUserBasket(userId, orderId);

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

        public async Task<IActionResult> Checkout(long orderId)
        {
            var userId = User.GetUserId();

            var model = await _orderService.GetUserCheckout(userId, orderId);

            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Payment

        public async Task<IActionResult> Payment(CheckoutViewModel checkout)
        {
            var userId = User.GetUserId();

            //Payment Method

            var result = await _orderService.Checkout(userId, checkout);

            switch (result)
            {
                case CheckoutResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفق انجام شد";
                    return RedirectToAction("Checkout", "Store", new { orderId = checkout.OrderId});

                case CheckoutResult.Failure:
                    TempData[ErrorMessage] = "عملیات با شکست انجام شد";
                    return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}
