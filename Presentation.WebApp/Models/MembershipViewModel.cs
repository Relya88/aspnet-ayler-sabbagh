using Application.Memberships;
using Domain.Aggregates.Memberships;

namespace Presentation.WebApp.Models;

public class MembershipViewModel
{

    public List<Membership> Memberships { get; set; } = [];
}
