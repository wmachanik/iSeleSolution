using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class PriceGroupConfiguration : IEntityTypeConfiguration<PriceGroup>
    {
        public void Configure(EntityTypeBuilder<PriceGroup> PriceGroupBuilder)
        {
            PriceGroupBuilder.HasIndex(pg => pg.PriceGroupName);
            PriceGroupBuilder.HasOne(pg => pg.PriceListType)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}