using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

// hanterar set password-sidan
public class SetPasswordController : Controller
{
    // visar set password-sidan
    public IActionResult Index()
    {
        return View();
    }
}