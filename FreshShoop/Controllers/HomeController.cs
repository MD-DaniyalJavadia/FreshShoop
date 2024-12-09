using FreshShoop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FreshShoop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult about()
        {
            return View();
        }


        public IActionResult cart()
        {
            return View();
        }


        public IActionResult checkout()
        {
            return View();
        }



        public IActionResult contactus()
        {
            return View();
        }

        public IActionResult gallery()
        {
            return View();
        }


        public IActionResult myaccount()
        {
            return View();
        }


        public IActionResult shop()
        {
            return View();
        }

        public IActionResult shopdetail()
        {
            return View();
        }

        public IActionResult wishlist()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
