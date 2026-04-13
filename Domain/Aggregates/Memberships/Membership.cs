namespace Domain.Aggregates.Memberships;

// representerar ett medlemskap i systemet. Innehåller unikt id, pris per månad, kort beskrivning och typ av val
public sealed class Membership
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;
}