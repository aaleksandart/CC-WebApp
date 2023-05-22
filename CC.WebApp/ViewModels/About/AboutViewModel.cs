using CC.Data.Models;

namespace CC.WebApp.ViewModels.About
{
    public class AboutViewModel
    {
        public IEnumerable<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
    }
}
