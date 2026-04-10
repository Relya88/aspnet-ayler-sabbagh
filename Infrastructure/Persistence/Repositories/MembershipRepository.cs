using Domain.Abstractions.Repositories;
using Domain.Aggregates.Memberships;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Repositories;

//repo som hanterar datanrop för medlemskap och definerar hur Membership konverteras till/från MembershipEntity samt hur uppdateringar av entity görs
public sealed class MembershipRepository(DataContext context)
    : RepositoryBase<Membership, string, MembershipEntity, DataContext>(context),
      IMembershipRepository
{
    protected override void ApplyPropertyUpdates(MembershipEntity entity, Membership model)
    {
        throw new NotImplementedException();
    }

    protected override string GetId(Membership model)
    {
        throw new NotImplementedException();
    }

    protected override Membership ToDomainModel(MembershipEntity entity)
    {
        throw new NotImplementedException();
    }

    protected override MembershipEntity ToEntity(Membership model)
    {
        throw new NotImplementedException();
    }
}
