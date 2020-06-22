using iSele.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.General
{
    internal class DemoEquipmentModelConfig : IEntityTypeConfiguration<DemoEquipment>
    {
        public void Configure(EntityTypeBuilder<DemoEquipment> demoEquipmentBuilder)
        {
            demoEquipmentBuilder.HasIndex(de => de.DemoEquipmentName).IsUnique();
            demoEquipmentBuilder.HasOne(de => de.EquipmentType)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            demoEquipmentBuilder.HasMany(de => de.DemoEquipmentUsages)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}