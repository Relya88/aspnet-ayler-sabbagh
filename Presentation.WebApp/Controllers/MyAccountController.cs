using Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;

// kräver inloggning
[Authorize]
public class MyAccountController(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : Controller
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    // hämtar user-data
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);

        var model = new MyAccountViewModel
        {
            Id = user!.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber
        };

        return View(model);
    }

    // uppdaterar user-data
    [HttpPost]
    public async Task<IActionResult> Index(MyAccountViewModel model)
    {
        foreach (var error in ModelState)
        {
            Console.WriteLine($"{error.Key}: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
        }

        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.GetUserAsync(User);

        user!.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;
        user.UserName = model.Email;
        user.PhoneNumber = model.PhoneNumber;

        await _userManager.UpdateAsync(user);

        Console.WriteLine("USER UPDATED");

        return RedirectToAction("Index");
    }

    // tar bort användaren och loggar ut korrekt via Identity
    [HttpPost]
    public async Task<IActionResult> Delete()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null)
        {
            await _userManager.DeleteAsync(user);
        }

        // korrekt logout via Identity
        await _signInManager.SignOutAsync();

        Console.WriteLine("USER DELETED AND LOGGED OUT");

        return RedirectToAction("Index", "Home");
    }
}