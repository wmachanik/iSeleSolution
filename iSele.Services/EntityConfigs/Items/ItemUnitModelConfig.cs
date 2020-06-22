using iSele.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Items
{
    internal class ItemUnitModelConfig : IEntityTypeConfiguration<ItemUnit>
    {
        public void Configure(EntityTypeBuilder<ItemUnit> itemUnitBuilder)
        {
            itemUnitBuilder.HasIndex(iu => iu.UnitName).IsUnique();
        }
    }
}