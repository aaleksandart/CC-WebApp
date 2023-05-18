using CC.Data.Entities;
using CC.Data.Models;
using CC.Data.Services.Interfaces;
using CC.WebApp.ViewModels.About;
using CC.WebApp.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace CC.WebApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public AboutController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> About()
        {
            var viewmodel = new AboutViewModel();
            var employees = await _employeeService.GetAllEmployees();
            if (employees != null)
                viewmodel.Employees = employees;
            else
                viewmodel.Employees = new List<EmployeeModel>();

            return View(viewmodel);
        }
    }
}
