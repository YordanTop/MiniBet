using Microsoft.AspNetCore.Mvc;

namespace MiniBet.Controllers
{
    public class SlotsController : Controller
    {
        public IActionResult Index()
        {
            return View("../Slots/Slots");
        }
    }
}
