using iSele.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.General
{
    internal class CityModelConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> cityBuilder)
        {
            cityBuilder.HasIndex(cty => cty.CityName)
                .IsUnique();
            cityBuilder.HasOne(cty => cty.Area)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}