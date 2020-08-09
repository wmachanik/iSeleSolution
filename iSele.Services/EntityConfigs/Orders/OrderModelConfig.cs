using iSele.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Orders
{
    internal class OrderModelConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderBuilder)
        {
            orderBuilder.HasIndex(o => o.OrderDate);
            orderBuilder.HasOne(o => o.Customer)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            orderBuilder.HasOne(o => o.OrderOptions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            orderBuilder.HasOne(o => o.OrderPaymentOptions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            orderBuilder.HasOne(o => o.OrderMethodType)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            orderBuilder.HasOne(o => o.DeliveryBy)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            orderBuilder.HasMany(o => o.OrderLines)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}