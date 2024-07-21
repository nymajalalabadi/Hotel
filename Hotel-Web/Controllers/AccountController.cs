using GoogleReCaptcha.V3.Interface;
using Hotel_Application.Services.Interface;
using Hotel_Domain.Entities.Account;
using Hotel_Domain.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Hotel_Web.Controllers
{
    public class AccountController : BaseController
    {
        #region constractor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Register

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("register"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var result = await _userService.RegisterUser(register);

            switch (result)
            {
                case RegisterResult.EmailExists:
                    TempData[ErrorMessage] = "ایمیل وارد شده از قبل موجود است";
                    break;

                case RegisterResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("Login", "Account");
            }

            return View(register);
        }

        #endregion

        #region Login

        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string ReturnUrl = "")
        {
            var result = new LoginViewModel();

            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                result.ReturnUrl = ReturnUrl;
            }

            return View(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var result = await _userService.LoginUser(login);

            switch (result)
            {
                case LoginResult.UserIsBan:
                    TempData[WarningMessage] = "دسترسی شما به سایت مسدود می باشد .";
                    break;

                case LoginResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربر مورد نظر یافت نشد .";
                    break;

                case LoginResult.Success:

                    var user = await _userService.GetUserByEmail(login.Email);

                    #region Login User

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user!.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties { IsPersistent = login.IsRemeberMe };

                    await HttpContext.SignInAsync(principal, properties);

                    #endregion

                    TempData[SuccessMessage] = "خوش آمدید";

                    if (!string.IsNullOrEmpty(login.ReturnUrl))
                    {
                        return Redirect(login.ReturnUrl);
                    }

                    return Redirect("/");
            }

            return View(login);
        }

        #endregion

        #region Logout

        [Route("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");
        }

        #endregion


    }
}
