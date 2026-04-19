using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

// hanterar login-sidan
public class LoginController : Controller
{
    // visar login-sidan
    public IActionResult Index()
    {
        return View();
    }
}