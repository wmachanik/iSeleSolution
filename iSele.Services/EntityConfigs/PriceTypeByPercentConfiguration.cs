using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class PriceTypeByPercentConfiguration : IEntityTypeConfiguration<PriceTypeByPercent>
    {
        public void Configure(EntityTypeBuilder<PriceTypeByPercent> PriceTypeByPercentBuilder)
        {
            PriceTypeByPercentBuilder.HasIndex(ptbp => ptbp.PriceTypeByPercentName);
        }
    }
}