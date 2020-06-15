using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class PriceListTypeConfiguraton : IEntityTypeConfiguration<PriceListType>
    {
        public void Configure(EntityTypeBuilder<PriceListType> PriceListTypeBuilder)
        {
            PriceListTypeBuilder.HasIndex(plt => plt.PriceListName);
        }
    }
}