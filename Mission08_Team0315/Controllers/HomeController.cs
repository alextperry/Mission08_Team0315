using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0315.Models;

namespace Mission08_Team0315.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

    }
}
