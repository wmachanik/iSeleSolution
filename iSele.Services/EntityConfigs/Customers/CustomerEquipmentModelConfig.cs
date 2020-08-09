using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Customers
{
    internal class CustomerEquipmentModelConfig : IEntityTypeConfiguration<CustomerEquipment>
    {
        public void Configure(EntityTypeBuilder<CustomerEquipment> customerEquipmentBuilder)
        {
            customerEquipmentBuilder.HasIndex(ce => ce.EquipSerialNo);
            //customerEquipmentBuilder.HasOne(ce => ce.Customer)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.SetNull);
            customerEquipmentBuilder.HasOne(ce => ce.EquipmentType)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}