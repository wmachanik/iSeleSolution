using iSele.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Items
{
    internal class PackagingModelConfig : IEntityTypeConfiguration<Packaging>
    {
        public void Configure(EntityTypeBuilder<Packaging> packagingBuilder)
        {
            packagingBuilder.HasIndex(pk => pk.PackagingName).IsUnique();
        }
    }
}