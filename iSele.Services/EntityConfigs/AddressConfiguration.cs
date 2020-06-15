using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> AddressBuilder)
        {
            AddressBuilder.HasIndex(adr => adr.AddressLine1);
            AddressBuilder.HasIndex(adr => adr.AddressLine2);
            AddressBuilder.HasIndex(adr => adr.AddressLine3);
            AddressBuilder.HasIndex(adr => adr.PostalCode);
            AddressBuilder.HasOne(cc => cc.City)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}