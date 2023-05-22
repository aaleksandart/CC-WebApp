using CC.Data.Entities;
using CC.Data.Models;
using CC.Data.Services.Interfaces;
using CC.WebApp.ViewModels.Admin;
using CC.WebApp.ViewModels.Tools;
using Microsoft.AspNetCore.Authorization;
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

        #region Tools

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddTool()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTool(AddToolViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Input value was not correct.";
                return View("AddTool", viewmodel);
            }
            try
            {
                var model = new ToolModel(viewmodel.ToolName, viewmodel.ToolDescription, Guid.NewGuid());
                await _toolService.AddTool(model);
            }
            catch
            {
                TempData["ErrorMessage"] = "Error occured when trying to save employee.";
                return View("AddTool", viewmodel);
            }
            return Redirect("/Admin/AddTool");
        }

        #endregion

        #region Employees

        [Authorize]
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeViewModel viewmodel)
        {
            TempData["ErrorMessage"] = "";
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Input value was not correct.";
                return View("AddEmployee", viewmodel);
            }
            try
            {
                var model = new EmployeeModel(viewmodel.EmployeeName, viewmodel.EmployeeRole);
                await _employeeService.AddEmployee(model);
            }
            catch
            {
                TempData["ErrorMessage"] = "Error occured when trying to save employee.";
                return View("AddEmployee", viewmodel);
            }
            return Redirect("/Admin/AddEmployee");
                
        }

        #endregion
    }
}
