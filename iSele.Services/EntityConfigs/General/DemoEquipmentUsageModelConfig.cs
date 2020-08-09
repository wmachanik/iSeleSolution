using iSele.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.General
{
    internal class DemoEquipmentUsageModelConfig : IEntityTypeConfiguration<DemoEquipmentUsage>
    {
        public void Configure(EntityTypeBuilder<DemoEquipmentUsage> demoEquipmentUsageBuilder)
        {
            demoEquipmentUsageBuilder.HasIndex(du => du.ReceiveDate);
            //demoEquipmentUsageBuilder.HasOne(du => du.Customer)
            //    .WithMany()
            //    .HasForeignKey(du=>du.CustomerID)
            //    .OnDelete(DeleteBehavior.SetNull);
            //// is this a good idea, since this table to basically the use of the demo equipment, if the equipment is deleted it should delete the associated usage records.
            //demoEquipmentUsageBuilder.HasOne(du => du.DemoEquipment)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Cascade); 


        }
    }
}