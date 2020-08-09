using iSele.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Orders
{
    internal class RecurringOrderModelConfig : IEntityTypeConfiguration<RecurringOrder>
    {
        public void Configure(EntityTypeBuilder<RecurringOrder> recurringOrderBuilder)
        {
            recurringOrderBuilder.HasIndex(ro => ro.DateLastDone);
            recurringOrderBuilder.HasOne(ro => ro.Customer)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            recurringOrderBuilder.HasOne(ro => ro.RecurringType)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            recurringOrderBuilder.HasOne(ro => ro.DeliveryBy)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            recurringOrderBuilder.HasMany(ro => ro.RecurringOrderItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}