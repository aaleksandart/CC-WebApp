using CC.Data.Models;

namespace CC.WebApp.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public IEnumerable<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
    }
}
