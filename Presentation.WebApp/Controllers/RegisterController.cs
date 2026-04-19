using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

// hanterar registrering
public class RegisterController : Controller
{
    // visar registreringssidan
    public IActionResult Index()
    {
        return View();
    }
}