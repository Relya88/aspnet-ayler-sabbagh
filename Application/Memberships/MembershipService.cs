using Domain.Abstractions.Repositories;
using Domain.Aggregates.Memberships;

namespace Application.Memberships;

// hanterar logik mellan controller och repo
public sealed class MembershipService(IMembershipRepository repo) : IMembershipService
{
    private readonly IMembershipRepository _repo = repo;

    // hämtar alla memberships
    public async Task<List<Membership>> GetAllAsync()
    {
        var result = await _repo.GetAllAsync();
        return result.ToList();
    }

    // skapar nytt membership
    public async Task CreateAsync(Membership membership)
    {
        await _repo.AddAsync(membership);
    }
}