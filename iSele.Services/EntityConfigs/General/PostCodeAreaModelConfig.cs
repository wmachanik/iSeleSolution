using iSele.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.General
{
    internal class PostCodeAreaModelConfig : IEntityTypeConfiguration<PostCodeArea>
    {
        public void Configure(EntityTypeBuilder<PostCodeArea> postCodeAreaBuilder)
        {
            postCodeAreaBuilder.HasIndex(pca => pca.PostCodeStart);
            postCodeAreaBuilder.HasIndex(pca => pca.PostCodeEnd);
            postCodeAreaBuilder.HasOne(pca => pca.AreaDaySetting)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}