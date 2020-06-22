using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Customers
{
    internal class CustomerPrefPerTypeModelConfig : IEntityTypeConfiguration<CustomerPrefPerType>
    {
        public void Configure(EntityTypeBuilder<CustomerPrefPerType> customerPrefPerTypebBuilder)
        {
            customerPrefPerTypebBuilder.HasKey(cppt => cppt.CustomerID);
            customerPrefPerTypebBuilder.HasOne(cppt => cppt.Item)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            customerPrefPerTypebBuilder.HasOne(cppt => cppt.Packaging)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            customerPrefPerTypebBuilder.HasOne(cppt => cppt.Variety)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}