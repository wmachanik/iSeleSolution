using iSele.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Items
{
    internal class ServiceTypeModelConfig : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> serviceTypeBuilder)
        {
            serviceTypeBuilder.HasIndex(st => st.ServiceTypeName).IsUnique();
        }
    }
}