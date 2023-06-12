using ASPNETCoreDemoIntroduction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETCoreDemoIntroduction.Controllers
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
            ViewData["MyData"] = "I am inserting data from controller in view!";
            ViewBag.Result = "It works";
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