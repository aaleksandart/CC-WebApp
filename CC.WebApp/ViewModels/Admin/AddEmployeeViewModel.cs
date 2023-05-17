using System.ComponentModel.DataAnnotations;

namespace CC.WebApp.ViewModels.Admin
{
    public class AddEmployeeViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "- Field can not be empty.")]
        public string EmployeeName { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "- Field can not be empty.")]
        public string EmployeeRole { get; set; } = string.Empty;
    }
}
