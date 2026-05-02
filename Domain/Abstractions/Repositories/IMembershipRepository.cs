using Domain.Aggregates.Memberships;

namespace Domain.Abstractions.Repositories;

//repo för membership som ärver bas-funk.
public interface IMembershipRepository : IRepositoryBase<Membership, string>
{
}
