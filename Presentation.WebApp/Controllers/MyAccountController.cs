using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

// hanterar my account-sidan
public class MyAccountController : Controller
{
    // ska visa my account-sidan
    public IActionResult Index()
    {
        return View();
    }
}