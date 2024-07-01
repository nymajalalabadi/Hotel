using GoogleReCaptcha.V3.Interface;
using Hotel_Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Controllers
{
    public class AccountController : BaseController
    {
        #region constractor

        private readonly IUserService _userService;

        private ICaptchaValidator _captchaValidator;

        public AccountController(IUserService userService, ICaptchaValidator captchaValidator)
        {
            _userService = userService;
            _captchaValidator = captchaValidator;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
