using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Controllers;

public class RegisterController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        return RedirectToAction("Index", "SetPassword", new { email = model.Email });
    }
}