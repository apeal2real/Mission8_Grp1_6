using Microsoft.AspNetCore.Mvc;
using Mission8_Grp1_6.Models;
using System.Diagnostics;

namespace Mission8_Grp1_6.Controllers
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
        public IActionResult Quadrants()
        {
            return View();
        }
    }
}
