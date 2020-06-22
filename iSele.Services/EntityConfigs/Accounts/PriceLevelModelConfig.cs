using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Accounts
{
    internal class PriceLevelModelConfig : IEntityTypeConfiguration<PriceLevel>
    {
        public void Configure(EntityTypeBuilder<PriceLevel> priceLevelBuilder)
        {
            priceLevelBuilder.HasIndex(pl => pl.PriceLevelName);
        }
    }
}