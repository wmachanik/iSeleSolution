using iSele.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Items
{
    internal class ItemTypeModelConfig : IEntityTypeConfiguration<ItemType>
    {
        public void Configure(EntityTypeBuilder<ItemType> itemTypeBuilder)
        {
            itemTypeBuilder.HasIndex(it => it.ItemTypeName).IsUnique();
        }
    }
}