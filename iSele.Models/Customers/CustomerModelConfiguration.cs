using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Models.Customers
{
    internal class CustomerModelConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(c => c.CustomerName).IsUnique();
            builder.HasIndex(c => c.PrimaryContactFirstName);
            builder.HasIndex(c => c.PrimaryContactLastName);
            builder.HasIndex(c => c.PrimaryContactEmail);
            builder.HasIndex(c => c.Telephone);
            builder.HasIndex(c => c.Mobile);
            builder.Property(c => c.CustomerTypeID).IsConcurrencyToken(false);
        }
    }
}