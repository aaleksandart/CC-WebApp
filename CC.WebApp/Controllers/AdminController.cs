using CC.Data.Entities;
using CC.WebApp.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CC.WebApp.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult AddTool()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTool(AddToolViewModel newTool)
        {
            var test = "";
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "This is my Error";
                return View("AddTool");
            }
            return View("AddEmployee");
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
    }
}
