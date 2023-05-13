using Microsoft.AspNetCore.Mvc;

namespace CC.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
