using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class InvoiceTypeConfiguration : IEntityTypeConfiguration<InvoiceType>
    {
        public void Configure(EntityTypeBuilder<InvoiceType> InvoiceTypeBuilder)
        {
            InvoiceTypeBuilder.HasIndex(ivt => ivt.InvoiceTypeName);
            InvoiceTypeBuilder.Property(ivt => ivt.IsEnabled).HasDefaultValue(true);
        }
    }
}