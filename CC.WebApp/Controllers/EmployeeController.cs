using CC.Data.Models;
using CC.Data.Services;
using CC.Data.Services.Interfaces;
using CC.WebApp.ViewModels.Employee;
using CC.WebApp.ViewModels.Tools;
using Microsoft.AspNetCore.Mvc;

namespace CC.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            //var viewmodel = new EmployeeViewModel();
            //var employees = await _employeeService.
            //if (employees != null)
            //    viewmodel.Tools = employees;
            //else
            //    viewmodel.Tools = new List<ToolModel>();

            //return View(viewmodel);
            return View();
        }
    }
}
