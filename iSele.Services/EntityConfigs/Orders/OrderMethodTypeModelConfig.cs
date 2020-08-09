using iSele.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Orders   
{
    internal class OrderMethodTypeModelConfig : IEntityTypeConfiguration<OrderMethodType>
    {
        public void Configure(EntityTypeBuilder<OrderMethodType> orderMethodTypeBuilder)
        {
            orderMethodTypeBuilder.HasIndex(omt => omt.MethodType).IsUnique();
        }
    }
}