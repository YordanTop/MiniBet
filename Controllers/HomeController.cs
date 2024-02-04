using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MiniBet.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View("HomePage");
        }

    }
}