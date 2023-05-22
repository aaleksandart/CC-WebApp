using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Auth0.AspNetCore.Authentication;
using CC.Data.Services.Interfaces;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using CC.Data.Models;

namespace CC.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task Login(string returnUrl = "/Account/LoginCreateUser")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl)
                .Build();
            
            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        [Authorize]
        public async Task Logout()
        {
            var claims = User.Claims;
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url.Action("Index", "Home"))
                .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> CreateUser()
        {
            var emailClaim = User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            var usernameClaim = User.Identity.Name;
            if (emailClaim != null && usernameClaim != null)
            {
                try
                {
                    var user = new UserModel(emailClaim, emailClaim, usernameClaim);
                    var success = await _userService.AddUser(user);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
                return false;
        }

        public async Task<IActionResult> LoginCreateUser()
        {
            var success = await CreateUser();
            if (success && User.Identity.IsAuthenticated)
                return RedirectToAction("Profile", "Profile");
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
