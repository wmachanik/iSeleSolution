using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Accounts
{
    internal class PriceTypeByValueModelConfig : IEntityTypeConfiguration<PriceTypeByValue>
    {
        public void Configure(EntityTypeBuilder<PriceTypeByValue> priceTypeByValueBuilder)
        {
            priceTypeByValueBuilder.HasIndex(ptbv => ptbv.PriceTypeByValueName);
        }
    }
}