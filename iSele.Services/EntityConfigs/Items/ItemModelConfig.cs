using iSele.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Items
{
    internal class ItemModelConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> itemModelBuilder)
        {
            itemModelBuilder.HasIndex(i => i.ItemName)
                .IsUnique();
            itemModelBuilder.HasIndex(i => i.SKU)
                .IsUnique();
            itemModelBuilder.Property(i => i.IsEnabled)
                .HasDefaultValue(true);
            itemModelBuilder.HasOne(i => i.ItemType)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            itemModelBuilder.HasOne(i => i.ItemType)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            itemModelBuilder.HasOne(i => i.ItemUnit)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            itemModelBuilder.HasOne(i=>i.VATTaxType)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}