using iSele.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Orders
{
    internal class OrderFulfillmentModelConfig : IEntityTypeConfiguration<OrderFulfillment>
    {
        public void Configure(EntityTypeBuilder<OrderFulfillment> orderFulfillmentBuilder)
        {
            orderFulfillmentBuilder.HasIndex(of => of.TrackingNumber);
            orderFulfillmentBuilder.HasIndex(of => of.DateFulfilled);
            orderFulfillmentBuilder.HasOne(of => of.FulfilledBy)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}