using iSele.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Items
{
    internal class ItemPriceModelConfig : IEntityTypeConfiguration<ItemPrice>
    {
        public void Configure(EntityTypeBuilder<ItemPrice> itemPriceBuilder)
        {
            itemPriceBuilder.HasOne(ip => ip.PriceListType)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}