using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Controllers;

// hanterar inloggning via Identity
public class LoginController(SignInManager<IdentityUser> signInManager) : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;

    // visar login-sidan
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // loggar in användaren och redirectar tydligt
    [HttpPost]
    
    public async Task<IActionResult> Index(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // hämtar användaren först via email och loggar in korrekt
        var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Fel email eller lösenord");
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(
            user.UserName!,
            model.Password,
            false,
            false
        );

        if (result.Succeeded)
        {
            Console.WriteLine("LOGIN SUCCESS");
            return RedirectToAction("Index", "MyAccount");
        }

        Console.WriteLine("LOGIN FAILED");

        ModelState.AddModelError(string.Empty, "Fel email eller lösenord");
        return View(model);


    }

    // loggar ut användaren och redirectar till startsidan
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {

        Console.WriteLine("USER LOGGED OUT");

        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}