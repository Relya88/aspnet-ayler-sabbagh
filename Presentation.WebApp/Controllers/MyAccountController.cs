using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

// kräver inloggning för att nå MyAccount
[Authorize]
public class MyAccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}