using CC.Data.Models;
using CC.Data.Services.Interfaces;
using CC.WebApp.ViewModels.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CC.WebApp.Controllers
{
    public class ToolsController : Controller
    {
        private readonly IToolService _toolService;
        private readonly IAvailabilityService _availabilityService;
        public ToolsController(IToolService toolService, IAvailabilityService availabilityService)
        {
            _toolService = toolService;
            _availabilityService = availabilityService;
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
        public async Task<IActionResult> ToolDetails(int id)
        {
            var viewmodel = new ToolDetailsViewModel();
            viewmodel.ToolId = id;
            var availability = await _availabilityService.GetAvailability(id);
            var tool = await _toolService.GetToolById(id);
            if (tool != null)
                viewmodel.ToolName = tool.Name ?? string.Empty;
            if (availability)
                viewmodel.Availability = true;

            
            return View(viewmodel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ToolDetails(ToolDetailsViewModel viewmodel)
        {
            TempData["SuccessMessage"] = "";
            var userEmail = User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            if (viewmodel.ToolId == 0 || userEmail == null)
            {
                TempData["SuccessMessage"] = "Error occured when trying to complete booking of tool.";
                return View("ToolDetails");
            }
            try
            {
                var success = await _toolService.RentTool(viewmodel.ToolId, userEmail);
                if (success)
                {
                    viewmodel.Availability = await _availabilityService.GetAvailability(viewmodel.ToolId);
                    TempData["SuccessMessage"] = "Successfully booked tool.";
                    return View("ToolDetails", viewmodel);
                }
            }
            catch { }
            TempData["SuccessMessage"] = "Error occured when trying to complete booking of tool.";
            return View("ToolDetails", viewmodel);
        }
    }
}
