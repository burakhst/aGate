using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace aGate.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> AutoLogin(string role)
        {
            if (string.IsNullOrEmpty(role))
                return RedirectToAction("Login", "Default");

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, role),
            new Claim(ClaimTypes.Role, role)
        };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            );

            // role'e göre yönlendir
            if (role == "CampaignManager")
                return RedirectToAction("Index", "CampaingManager");

            if (role == "Staff")
                return RedirectToAction("Index", "Staff");

            return RedirectToAction("Login", "Default");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Default");
        }
    }
}
