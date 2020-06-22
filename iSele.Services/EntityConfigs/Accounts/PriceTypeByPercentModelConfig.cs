using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Accounts
{
    internal class PriceTypeByPercentModelConfig : IEntityTypeConfiguration<PriceTypeByPercent>
    {
        public void Configure(EntityTypeBuilder<PriceTypeByPercent> priceTypeByPercentBuilder)
        {
            priceTypeByPercentBuilder.HasIndex(ptbp => ptbp.PriceTypeByPercentName).IsUnique();            
        }
    }
}