using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Accounts
{
    internal class PriceGroupModelConfig : IEntityTypeConfiguration<PriceGroup>
    {
        public void Configure(EntityTypeBuilder<PriceGroup> priceGroupBuilder)
        {
            priceGroupBuilder.HasIndex(pg => pg.PriceGroupName).IsUnique();
            priceGroupBuilder.HasOne(pg => pg.PriceListType)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}