using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

public class HomeController : Controller
{
    // testar om användaren är inloggad
    public IActionResult Index()
    {
        if (User.Identity!.IsAuthenticated)
            Console.WriteLine("USER IS LOGGED IN");

        return View();
    }
}
