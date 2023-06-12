using ASPNETCoreDemoIntroduction.Models;
using ASPNETCoreDemoIntroduction.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreDemoIntroduction.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddCarViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
