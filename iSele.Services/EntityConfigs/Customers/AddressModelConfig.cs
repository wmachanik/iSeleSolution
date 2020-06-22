using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Customers
{
    internal class AddressModelConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> addressBuilder)
        {
            addressBuilder.HasIndex(adr => adr.AddressLine1);
            addressBuilder.HasIndex(adr => adr.AddressLine2);
            addressBuilder.HasIndex(adr => adr.AddressLine3);
            addressBuilder.HasIndex(adr => adr.PostalCode);
            addressBuilder.HasOne(cc => cc.City)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}