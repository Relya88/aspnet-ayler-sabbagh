namespace Infrastructure.Persistence.Entities;

// databastabell för membership
public sealed class MembershipEntity
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;
}
