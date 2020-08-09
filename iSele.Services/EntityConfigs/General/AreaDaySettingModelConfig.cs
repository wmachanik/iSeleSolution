using iSele.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.General
{
    internal class AreaDaySettingModelConfig : IEntityTypeConfiguration<AreaDaySetting>
    {
        public void Configure(EntityTypeBuilder<AreaDaySetting> areaDaySettingBuilder)
        {
            areaDaySettingBuilder.HasOne(ard => ard.Area)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            areaDaySettingBuilder.HasOne(ads => ads.PreperationDayOfWeek)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}