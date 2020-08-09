using iSele.Models.Repairs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Repairs
{
    internal class RepairFaultModelConfig : IEntityTypeConfiguration<RepairFault>
    {
        public void Configure(EntityTypeBuilder<RepairFault> repairFaultBuilder)
        {
            repairFaultBuilder.HasIndex(rpf => new { rpf.SortOrder, rpf.RepairFaultName });
            repairFaultBuilder.HasIndex(rpf => rpf.RepairFaultName).IsUnique();
            repairFaultBuilder.Property(rpf => rpf.RepairFaultName).IsRequired();

        }
    }
}