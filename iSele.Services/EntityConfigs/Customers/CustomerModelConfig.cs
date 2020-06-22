using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Customers
{
    internal class CustomerModelConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customerBuilder)
        {
            customerBuilder.HasIndex(c => c.CustomerName)
                .IsUnique();
            customerBuilder.HasIndex(c => c.PrimaryContactFirstName);
            customerBuilder.HasIndex(c => c.PrimaryContactLastName);
            customerBuilder.HasIndex(c => c.PrimaryContactEmail);
            customerBuilder.HasIndex(c => c.Telephone);
            customerBuilder.HasIndex(c => c.Mobile);
            customerBuilder.Property(c => c.IsMobilePrimary)
                .HasDefaultValue(false);
            customerBuilder.Property(c => c.IsEnabled)
                .HasDefaultValue(true);
            customerBuilder.HasOne(c => c.CustomerType)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            customerBuilder.HasOne(c => c.CustomerFulfilmentOptions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            customerBuilder.HasOne(c => c.CustomerAccountingOptions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            //pCustomerBuilder.HasOne(c => c.RecurringOrder).WithOne().OnDelete(DeleteBehavior.SetNull);
            customerBuilder.HasMany(c => c.CustomerPrefPerTypes)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            customerBuilder.HasMany(c => c.CustomerEquipment)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            customerBuilder.HasMany(c => c.CustomerContacts)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}