using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

internal class MembershipConfiguration : IEntityTypeConfiguration<MembershipEntity>
{
    //fick ändra metoden helt från throw new NotImplementedException då jag fick mycket error.
    //tog hjälp av chatgpt
    public void Configure(EntityTypeBuilder<MembershipEntity> builder)
    {
        builder.HasKey(x => x.Id); // satte primary key

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Price)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(500);
    }
}
