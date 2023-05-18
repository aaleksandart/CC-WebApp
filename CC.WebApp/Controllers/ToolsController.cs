using CC.Data.Models;
using CC.Data.Services.Interfaces;
using CC.WebApp.ViewModels.Tools;
using Microsoft.AspNetCore.Mvc;

namespace CC.WebApp.Controllers
{
    public class ToolsController : Controller
    {
        private readonly IToolService _toolService;
        public ToolsController(IToolService toolService)
        {
            _toolService = toolService;
        }

        [HttpGet]
        public async Task<IActionResult> Tools()
        {
            var viewmodel = new ToolsViewModel();
            var tools = await _toolService.GetAllTools();
            if (tools != null)
                viewmodel.Tools = tools;
            else
                viewmodel.Tools = new List<ToolModel>();

            return View(viewmodel);
        }

        [HttpGet]
        [Route("Tools/ToolDetails/{id?}")]
        public IActionResult ToolDetails(int id)
        {
            return View();
        }
    }
}
