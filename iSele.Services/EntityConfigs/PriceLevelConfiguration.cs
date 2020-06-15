using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class PriceLevelConfiguration : IEntityTypeConfiguration<PriceLevel>
    {
        public void Configure(EntityTypeBuilder<PriceLevel> PriceLevelBuilder)
        {
            PriceLevelBuilder.HasIndex(pl => pl.PriceLevelName);
        }
    }
}