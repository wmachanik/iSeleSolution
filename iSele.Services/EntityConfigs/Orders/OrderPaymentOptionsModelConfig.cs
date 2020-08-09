using iSele.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Orders
{
    internal class OrderPaymentOptionsModelConfig : IEntityTypeConfiguration<OrderPaymentOptions>
    {
        public void Configure(EntityTypeBuilder<OrderPaymentOptions> orderPaymentOptionsBuilder)
        {
            orderPaymentOptionsBuilder.HasIndex(opo => opo.OrderID);
            orderPaymentOptionsBuilder.HasOne(opo => opo.PaymentType)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}