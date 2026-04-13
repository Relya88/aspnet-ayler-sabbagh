using Domain.Abstractions.Repositories;
using Domain.Aggregates.Memberships;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Repositories;

//repo som hanterar datanrop för medlemskap och definerar hur Membership konverteras till/från MembershipEntity samt hur uppdateringar av entity görs
public sealed class MembershipRepository(DataContext context)
    : RepositoryBase<Membership, string, MembershipEntity, DataContext>(context),
      IMembershipRepository

{// mappar entity --> domain
    protected override Membership ToDomainModel(MembershipEntity entity)
    {
        return new Membership
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Description = entity.Description
        };
    }

    // mappar domain -> entity
    protected override MembershipEntity ToEntity(Membership model)
    {
        return new MembershipEntity
        {
            Id = model.Id,
            Name = model.Name,
            Price = model.Price,
            Description = model.Description
        };
    }

    // uppdaterar entity med nya värdeen
    protected override void ApplyPropertyUpdates(MembershipEntity entity, Membership model)
    {
        entity.Name = model.Name;
        entity.Price = model.Price;
        entity.Description = model.Description;
    }

    //hämtar id från domain
    protected override string GetId(Membership model)
    {
        return model.Id;
    }
}
