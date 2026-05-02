using Domain.Aggregates.Memberships;
using Xunit;

public class MembershipTests
{
    [Fact]
    public void Membership_Creation_Should_Set_Expected_Values()
    {
        // Arrange
        var membership = new Membership
        {
            Name = "Basic Membership",
            Price = 299,
            Description = "Access to gym facilities"
        };

        // Assert
        Assert.NotNull(membership.Id);
        Assert.Equal("Basic Membership", membership.Name);
        Assert.Equal(299, membership.Price);
        Assert.Equal("Access to gym facilities", membership.Description);
    }
}