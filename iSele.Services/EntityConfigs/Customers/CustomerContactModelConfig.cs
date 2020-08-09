using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Customers
{
    internal class CustomerContactModelConfig : IEntityTypeConfiguration<CustomerContact>
    {
        public void Configure(EntityTypeBuilder<CustomerContact> customerCotnactBuilder)
        {
            customerCotnactBuilder.HasIndex(cc => cc.FirstName);
            customerCotnactBuilder.HasIndex(cc => cc.LastName);
            customerCotnactBuilder.HasIndex(cc => cc.Email);
            customerCotnactBuilder.HasIndex(cc => cc.Telephone);
            customerCotnactBuilder.HasIndex(cc => cc.Mobile);
            customerCotnactBuilder.Property(cc => cc.IsEnabled).HasDefaultValue(true);
            customerCotnactBuilder.HasOne(cc => cc.PostalAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            customerCotnactBuilder.HasOne(cc => cc.ShippingAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            customerCotnactBuilder.HasOne(cc => cc.ContactType)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);            
        }
    }
}