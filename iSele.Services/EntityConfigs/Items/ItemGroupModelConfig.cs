using iSele.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Items
{
    internal class ItemGroupModelConfig : IEntityTypeConfiguration<ItemGroup>
    {
        public void Configure(EntityTypeBuilder<ItemGroup> itemGroupBuilder)
        {
            itemGroupBuilder.HasOne(ig => ig.GroupItem)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            itemGroupBuilder.HasOne(ig => ig.Item)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}