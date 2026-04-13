using Domain.Aggregates.Memberships;

namespace Application.Memberships;

// definierar vad jag kan göra med memberships
public interface IMembershipService
{
    Task<List<Membership>> GetAllAsync();

    Task CreateAsync(Membership membership);
}
