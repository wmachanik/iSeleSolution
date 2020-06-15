using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class CustomerAccountingOptionsConfiguration : IEntityTypeConfiguration<CustomerAccountingOptions>
    {
        public void Configure(EntityTypeBuilder<CustomerAccountingOptions> CustomerAccountingOptionsBuilder)
        {
            CustomerAccountingOptionsBuilder.HasIndex(cao => cao.AccountContactName);
            CustomerAccountingOptionsBuilder.HasIndex(cao => cao.FullCompanyName);
            CustomerAccountingOptionsBuilder.HasIndex(cao => cao.AccEmails);
            CustomerAccountingOptionsBuilder.HasIndex(cao => cao.VATTaxNum);
            CustomerAccountingOptionsBuilder.Property(cao => cao.AccountIsEnabled).HasDefaultValue(true);
            CustomerAccountingOptionsBuilder.Property(cao => cao.IsPORequired).HasDefaultValue(false);
            CustomerAccountingOptionsBuilder.Property(cao => cao.OnlyEmailInvoices).HasDefaultValue(true);
            CustomerAccountingOptionsBuilder.HasOne(cao => cao.PrimaryBillingAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
            CustomerAccountingOptionsBuilder.HasOne(cao => cao.PrimaryShippingAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
            CustomerAccountingOptionsBuilder.HasOne(cao => cao.PaymentTerms)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
            CustomerAccountingOptionsBuilder.HasOne(cao => cao.PriceLevel)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}