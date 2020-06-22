using iSele.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.General
{
    internal class EquipmentTypeModelConfig : IEntityTypeConfiguration<EquipmentType>
    {
        public void Configure(EntityTypeBuilder<EquipmentType> equipmentTypeBuilder)
        {
            equipmentTypeBuilder.HasIndex(et => et.EquipmentTypeName).IsUnique();
        }
    }
}