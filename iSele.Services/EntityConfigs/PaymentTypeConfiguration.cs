using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> PaymentTypeBuilder)
        {
            PaymentTypeBuilder.HasIndex(pyty => pyty.PaymentTypeName);
            PaymentTypeBuilder.Property(pyty => pyty.IsEnabled).HasDefaultValue(true);
        }
    }
}