using iSele.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.General
{
    internal class AreaDaySettingModelConfig : IEntityTypeConfiguration<AreaDaySetting>
    {
        public void Configure(EntityTypeBuilder<AreaDaySetting> areaDaySettingBuilder)
        {
            areaDaySettingBuilder.HasIndex(ads => ads.AreaName).IsUnique();
            areaDaySettingBuilder.HasOne(ads => ads.City)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            areaDaySettingBuilder.HasOne(ads => ads.PreperationDayOfWeek)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}