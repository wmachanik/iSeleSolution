using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class PriceTypeByValueConfiguration : IEntityTypeConfiguration<PriceTypeByValue>
    {
        public void Configure(EntityTypeBuilder<PriceTypeByValue> PriceTypeByValueBuilder)
        {
            PriceTypeByValueBuilder.HasIndex(ptbv => ptbv.PriceTypeByValueName);
        }
    }
}