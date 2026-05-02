using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers;

// hanterar kundservicesidan
public class CustomerServiceController : Controller
{
    // ska visa kundservicesidan
    public IActionResult Index()
    {
        return View();
    }
}