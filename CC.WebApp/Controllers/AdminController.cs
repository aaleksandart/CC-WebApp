using CC.Data.Entities;
using CC.Data.Models;
using CC.Data.Services.Interfaces;
using CC.WebApp.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CC.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IToolService _toolService;
        private readonly IEmployeeService _employeeService;
        public AdminController(IUserService userService, IToolService toolService, IEmployeeService employeeService)
        {
            _userService = userService;
            _toolService = toolService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult AddTool()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTool(AddToolViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "This is my Error";
                return View("AddTool", viewmodel);
            }
            return View("AddTool");
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeViewModel viewmodel)
        {
            TempData["ErrorMessage"] = "";
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Input value was not correct.";
                return View("AddEmployee", viewmodel);
            }
            try
            {
                var employee = new EmployeeModel(viewmodel.EmployeeName, viewmodel.EmployeeRole);
                _employeeService.AddEmployee(employee);
            }
            catch
            {
                TempData["ErrorMessage"] = "Error occured when trying to save employee.";
                return View("AddEmployee", viewmodel);
            }
            return Redirect("/Admin/AddEmployee");
                
        }
    }
}
