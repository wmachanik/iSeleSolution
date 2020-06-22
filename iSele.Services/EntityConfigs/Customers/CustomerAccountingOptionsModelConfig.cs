using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Customers
{
    internal class CustomerAccountingOptionsModelConfig : IEntityTypeConfiguration<CustomerAccountingOptions>
    {
        public void Configure(EntityTypeBuilder<CustomerAccountingOptions> customerAccountingOptionsBuilder)
        {
            customerAccountingOptionsBuilder.HasIndex(cao => cao.AccountContactName);
            customerAccountingOptionsBuilder.HasIndex(cao => cao.FullCompanyName);
            customerAccountingOptionsBuilder.HasIndex(cao => cao.AccEmails);
            customerAccountingOptionsBuilder.HasIndex(cao => cao.VATTaxNum);
            customerAccountingOptionsBuilder.Property(cao => cao.AccountIsEnabled).HasDefaultValue(true);
            customerAccountingOptionsBuilder.Property(cao => cao.IsPORequired).HasDefaultValue(false);
            customerAccountingOptionsBuilder.Property(cao => cao.OnlyEmailInvoices).HasDefaultValue(true);
            customerAccountingOptionsBuilder.HasOne(cao => cao.PrimaryBillingAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            customerAccountingOptionsBuilder.HasOne(cao => cao.PrimaryShippingAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            customerAccountingOptionsBuilder.HasOne(cao => cao.InvoiceType)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            customerAccountingOptionsBuilder.HasOne(cao => cao.PaymentTerms)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            customerAccountingOptionsBuilder.HasOne(cao => cao.PriceLevel)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}