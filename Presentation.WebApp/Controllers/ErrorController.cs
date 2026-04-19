using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

// hanterar errorsidor
public class ErrorController : Controller
{
    // visar 404-sidan
    public IActionResult NotFoundPage()
    {
        return View();
    }
}