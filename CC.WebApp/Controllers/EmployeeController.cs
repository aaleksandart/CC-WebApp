using Microsoft.AspNetCore.Mvc;

namespace CC.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
