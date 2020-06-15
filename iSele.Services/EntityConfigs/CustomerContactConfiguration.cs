using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class CustomerContactConfiguration : IEntityTypeConfiguration<CustomerContact>
    {
        public void Configure(EntityTypeBuilder<CustomerContact> CustomerCotnactBuilder)
        {
            CustomerCotnactBuilder.HasIndex(cc => cc.FirstName);
            CustomerCotnactBuilder.HasIndex(cc => cc.LastName);
            CustomerCotnactBuilder.HasIndex(cc => cc.Email);
            CustomerCotnactBuilder.HasIndex(cc => cc.Telephone);
            CustomerCotnactBuilder.HasIndex(cc => cc.Mobile);
            CustomerCotnactBuilder.Property(cc => cc.IsEnabled).HasDefaultValue(true);
            CustomerCotnactBuilder.HasOne(cc => cc.PostalAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
            CustomerCotnactBuilder.HasOne(cc => cc.ShippingAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
            CustomerCotnactBuilder.HasOne(cc => cc.ContactType)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}