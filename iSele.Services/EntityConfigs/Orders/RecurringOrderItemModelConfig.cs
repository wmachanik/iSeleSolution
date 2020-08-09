using iSele.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Orders
{
    internal class RecurringOrderItemModelConfig : IEntityTypeConfiguration<RecurringOrderItem>
    {
        public void Configure(EntityTypeBuilder<RecurringOrderItem> recurringOrderItemBuilder)
        {
            recurringOrderItemBuilder.HasOne(ri => ri.ItemRequired)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            recurringOrderItemBuilder.HasOne(ri => ri.Packaging)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            recurringOrderItemBuilder.HasOne(ri => ri.Variety)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}