using Microsoft.AspNetCore.Mvc;

namespace CC.WebApp.Controllers
{
    public class ToolsController : Controller
    {
        public IActionResult Tools()
        {
            return View();
        }

        public IActionResult ToolDetails()
        {
            return View();
        }
    }
}
