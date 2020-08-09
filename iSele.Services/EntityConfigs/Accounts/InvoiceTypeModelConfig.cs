using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Accounts
{
    internal class InvoiceTypeModelConfig : IEntityTypeConfiguration<InvoiceType>
    {
        public void Configure(EntityTypeBuilder<InvoiceType> invoiceTypeBuilder)
        {
            invoiceTypeBuilder.HasIndex(ivt => ivt.InvoiceTypeName).IsUnique();
            invoiceTypeBuilder.Property(ivt => ivt.IsEnabled).HasDefaultValue(true);
        }
    }
}