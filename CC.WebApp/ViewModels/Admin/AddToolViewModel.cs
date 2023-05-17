using System.ComponentModel.DataAnnotations;

namespace CC.WebApp.ViewModels.Admin
{
    public class AddToolViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "- Field can not be empty.")]
        public string ToolName { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "- Field can not be empty.")]
        public string ToolDescription { get; set; } = string.Empty;
    }
}
