using CC.Data.Repositories;

namespace CC.WebApp.ViewModels.Tools
{
    public class ToolDetailsViewModel
    {
        public int ToolId { get; set; }
        public bool Availability { get; set; } = false;
    }
}
