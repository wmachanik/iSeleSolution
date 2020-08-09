using iSele.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Orders
{
    internal class RecurringTypeModelConfig : IEntityTypeConfiguration<RecurringType>
    {
        public void Configure(EntityTypeBuilder<RecurringType> recurringTypeBuilder)
        {
            recurringTypeBuilder.HasIndex(rt => rt.TypeName).IsUnique();
        }
    }
}