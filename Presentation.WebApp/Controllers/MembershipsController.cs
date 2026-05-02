using Application.Memberships;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Domain.Aggregates.Memberships;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Controllers;

// kräver inloggning för att skapa membership
[Authorize]
public class MembershipsController(IMembershipService service) : Controller
{
    private readonly IMembershipService _service = service;

    // visar alla medlemskap
    public async Task<IActionResult> Index()
    {
        var memberships = await _service.GetAllAsync();

        var viewModel = new MembershipViewModel
        {
            Memberships = memberships
        };

        return View(viewModel);
    }

    // skapar membership kopplat till inloggad user
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var membership = new Membership
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Standard",
            Price = 299,
            Description = "Basic membership",
            UserId = userId!
        };

        await _service.CreateAsync(membership);

        return RedirectToAction("Index");
    }
}