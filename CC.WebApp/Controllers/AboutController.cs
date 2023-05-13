using Microsoft.AspNetCore.Mvc;

namespace CC.WebApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
