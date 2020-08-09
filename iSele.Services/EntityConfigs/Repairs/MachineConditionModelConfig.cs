using iSele.Models.Repairs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Repairs
{
    internal class MachineConditionModelConfig : IEntityTypeConfiguration<MachineCondition>
    {
        public void Configure(EntityTypeBuilder<MachineCondition> machineConditionBuilder)
        {
            machineConditionBuilder.HasIndex(rpm => new { rpm.SortOrder, rpm.ConditionName });
            machineConditionBuilder.HasIndex(rpm => rpm.ConditionName).IsUnique();

        }
    }
}