using iSele.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs
{
    internal class VATTaxTypeConfiguration : IEntityTypeConfiguration<VATTaxType>
    {
        public void Configure(EntityTypeBuilder<VATTaxType> VATTaxTypeBuilder)
        {
            VATTaxTypeBuilder.HasIndex(vt => vt.VATTaxName);
        }
    }
}