using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Accounts
{
    internal class PaymentTypeModelConfig : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> paymentTypeBuilder)
        {
            paymentTypeBuilder.HasIndex(pyty => pyty.PaymentTypeName).IsUnique();
            paymentTypeBuilder.Property(pyty => pyty.IsEnabled).HasDefaultValue(true);
        }
    }
}