using iSele.Models.Repairs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Repairs

{
    internal class RepairStatusModelConfig : IEntityTypeConfiguration<RepairStatus>
    {
        public void Configure(EntityTypeBuilder<RepairStatus> repairStatusBuilder)
        {
            repairStatusBuilder.HasIndex(rps => new { rps.SortOrder, rps.RepairStatusName });
            repairStatusBuilder.HasIndex(rps => rps.RepairStatusName).IsUnique();

        }
    }
}