using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreshShoop.Controllers
{
    public class adminController : Controller
    {
        [Authorize]

        public IActionResult Index()
        {
            return View();
        }
    }
}
