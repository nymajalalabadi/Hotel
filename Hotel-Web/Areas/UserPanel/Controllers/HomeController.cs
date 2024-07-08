using Microsoft.AspNetCore.Mvc;

namespace Hotel_Web.Areas.UserPanel.Controllers
{
    public class HomeController : UserPanelBaseController
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
