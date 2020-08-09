using iSele.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace iSele.Services.EntityConfigs.General
{
    internal class AreaModelConfig : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> areaBuilder)
        {
            areaBuilder.HasIndex(ar => ar.AreaName)
                .IsUnique();
            areaBuilder.Property(ar => ar.EstimatedDeliveryDelay)
                .HasDefaultValue(Convert.ToInt16(0));

            areaBuilder.HasMany(ar => ar.AreaDaySettings)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}