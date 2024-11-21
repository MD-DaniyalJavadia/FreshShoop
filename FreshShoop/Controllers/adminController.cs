using Microsoft.AspNetCore.Mvc;

namespace FreshShoop.Controllers
{
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
