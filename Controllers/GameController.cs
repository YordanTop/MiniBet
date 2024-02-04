using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace MiniBet.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Game2()
        {
            return View("../Home/HomePage");
        }

        public IActionResult Game()
        {
            return View("CoinFlip");
        }
    }
}
