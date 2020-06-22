using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Accounts
{
    internal class PaymentTermModelConfig : IEntityTypeConfiguration<PaymentTerm>
    {
        public void Configure(EntityTypeBuilder<PaymentTerm> paymentTermBuilder)
        {
            paymentTermBuilder.HasIndex(pyt => pyt.PaymentTermName).IsUnique();
            paymentTermBuilder.Property(pyt => pyt.UseDays).HasDefaultValue(false);
            paymentTermBuilder.Property(pyt => pyt.IsEnabled).HasDefaultValue(true);
        }
    }
}