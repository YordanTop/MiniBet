using Microsoft.AspNetCore.Mvc;

namespace MiniBet.Controllers
{
    public class Info : Controller
    {
        public IActionResult Index()
        {
            return View("Info");
        }
    }
}
