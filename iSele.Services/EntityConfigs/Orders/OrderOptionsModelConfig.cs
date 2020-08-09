using iSele.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Orders
{
    internal class OrderOptionsModelConfig : IEntityTypeConfiguration<OrderOptions>
    {
        public void Configure(EntityTypeBuilder<OrderOptions> orderOptionsBuilder)
        {
            //orderOptionsBuilder.HasIndex(oo => oo.)
        }
    }
}