using iSele.Models.Repairs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Repairs
{
    internal class RepairModelConfig : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> repairBuilder)
        {
            repairBuilder.HasIndex(rp => rp.EquipmentSerialNumber);
            repairBuilder.HasIndex(rp => rp.JobCardNumber);
            repairBuilder.HasOne(rp => rp.Customer)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            repairBuilder.HasOne(rp => rp.EquipmentType)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            repairBuilder.HasOne(rp => rp.SwopOutEquipment)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            repairBuilder.HasOne(rp => rp.MachineCondition)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            repairBuilder.HasOne(rp => rp.RepairFault)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            repairBuilder.HasOne(rp => rp.RepairStatus)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}