using CC.Data.Context;
using CC.Data.Services;
using CC.Data.Services.Interfaces;
using CC.WebApp.ViewModels.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CC.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IRentDataService _rentDataService;
        public ProfileController(IRentDataService rentDataService)
        {
            _rentDataService = rentDataService;
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var viewmodel = new ProfileViewModel();
            viewmodel.Name = User.Identity.Name ?? string.Empty;
            viewmodel.Email = User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault() ?? string.Empty;
            if (!string.IsNullOrEmpty(viewmodel.Email))
            {
                viewmodel.CurrentRentals = await _rentDataService.GetCurrentRentData(viewmodel.Email);
                viewmodel.RentHistory = await _rentDataService.GetRentDataByEmail(viewmodel.Email);
            }
            return View(viewmodel);
        }
    }
}
