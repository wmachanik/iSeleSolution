using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class CustomerModelConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> CustomerBuilder)
        {
            CustomerBuilder.HasIndex(c => c.CustomerName).IsUnique();
            CustomerBuilder.HasIndex(c => c.PrimaryContactFirstName);
            CustomerBuilder.HasIndex(c => c.PrimaryContactLastName);
            CustomerBuilder.HasIndex(c => c.PrimaryContactEmail);
            CustomerBuilder.HasIndex(c => c.Telephone);
            CustomerBuilder.HasIndex(c => c.Mobile);
            CustomerBuilder.Property(c => c.IsMobilePrimary)
                .HasDefaultValue(false);
            CustomerBuilder.Property(c => c.IsEnabled)
                .HasDefaultValue(true);
            CustomerBuilder.HasOne(c => c.CustomerType)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            CustomerBuilder.HasOne(c => c.CustomerFulfilmentOptions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            CustomerBuilder.HasOne(c => c.CustomerAccountingOptions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            //pCustomerBuilder.HasOne(c => c.RecurringOrder).WithOne().OnDelete(DeleteBehavior.SetNull);
            CustomerBuilder.HasMany(c => c.CustomerPrefPerTypes)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            CustomerBuilder.HasMany(c => c.CustomerEquipment)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            CustomerBuilder.HasMany(c => c.CustomerContacts)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}