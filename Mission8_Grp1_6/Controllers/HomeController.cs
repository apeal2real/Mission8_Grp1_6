using Microsoft.AspNetCore.Mvc;
using Mission8_Grp1_6.Models;
using System.Diagnostics;

namespace Mission8_Grp1_6.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult AddEdit()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
