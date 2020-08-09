using iSele.Models.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Notifications
{
    internal class NotificationEmailTextModelConfig : IEntityTypeConfiguration<NotificationEmailText>
    {
        public void Configure(EntityTypeBuilder<NotificationEmailText> notificationEmailTextBuilder)
        {
            throw new System.NotImplementedException();
        }
    }
}