using iSele.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Items
{
    internal class VarietyModelConfig : IEntityTypeConfiguration<Variety>
    {
        public void Configure(EntityTypeBuilder<Variety> varietyBuilder)
        {
            varietyBuilder.HasIndex(v => v.VarietyName).IsUnique();
        }
    }
}