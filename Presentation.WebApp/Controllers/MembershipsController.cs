using Application.Memberships;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Controllers;

// hanterar medlemssidor
public class MembershipsController(IMembershipService service) : Controller
{
    private readonly IMembershipService _service = service;

    //ska visa alla medlmeskap
    public async Task<IActionResult> Index()
    {
        var memberships = await _service.GetAllAsync();

        var viewModel = new MembershipViewModel
        {
            Memberships = memberships
        };

        return View(viewModel);
    }
}