using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class PaymentTermConfiguration : IEntityTypeConfiguration<PaymentTerm>
    {
        public void Configure(EntityTypeBuilder<PaymentTerm> PaymentTermBuilder)
        {
            PaymentTermBuilder.HasIndex(pyt => pyt.PaymentTermName);
            PaymentTermBuilder.Property(pyt => pyt.UseDays).HasDefaultValue(false);
            PaymentTermBuilder.Property(pyt => pyt.IsEnabled).HasDefaultValue(true);
        }
    }
}