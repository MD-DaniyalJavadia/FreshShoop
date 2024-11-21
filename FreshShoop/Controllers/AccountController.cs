using Microsoft.AspNetCore.Mvc;

namespace FreshShoop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View("Register");
        }
    }
}
