using CC.Data.Models;

namespace CC.WebApp.ViewModels.Tools
{
    public class ToolsViewModel
    {
        public IEnumerable<ToolModel> Tools { get; set; } = new List<ToolModel>();
    }
}
