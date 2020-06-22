using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Accounts
{
    internal class PriceListTypeModelConfig : IEntityTypeConfiguration<PriceListType>
    {
        public void Configure(EntityTypeBuilder<PriceListType> priceListTypeBuilder)
        {
            priceListTypeBuilder.HasIndex(plt => plt.PriceListName);
        }
    }
}