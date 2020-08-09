using iSele.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Orders
{
    internal class OrderLineModelConfig : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> orderLineBuilder)
        {
            orderLineBuilder.HasIndex(ol => ol.OrderID);
            orderLineBuilder.HasOne(ol=>ol.Item)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            orderLineBuilder.HasOne(ol => ol.Packaging)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            orderLineBuilder.HasOne(ol => ol.Variety)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}