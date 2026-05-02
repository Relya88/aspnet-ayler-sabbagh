using Domain.Abstractions.Repositories;
using Domain.Aggregates.Memberships;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Repositories;

public sealed class MembershipRepository(DataContext context)
    : RepositoryBase<Membership, string, MembershipEntity, DataContext>(context),
      IMembershipRepository
{
    // mappar entity --> domain
    protected override Membership ToDomainModel(MembershipEntity entity)
    {
        return new Membership
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Description = entity.Description,
            UserId = entity.UserId
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
            Description = model.Description,
            UserId = model.UserId
        };
    }

    // uppdaterar entity med nya värden
    protected override void ApplyPropertyUpdates(MembershipEntity entity, Membership model)
    {
        entity.Name = model.Name;
        entity.Price = model.Price;
        entity.Description = model.Description;
        entity.UserId = model.UserId;
    }

    protected override string GetId(Membership model)
    {
        return model.Id;
    }
}