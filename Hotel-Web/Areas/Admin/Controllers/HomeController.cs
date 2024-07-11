using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
