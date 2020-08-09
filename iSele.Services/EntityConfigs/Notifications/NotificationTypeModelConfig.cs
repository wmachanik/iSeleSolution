using iSele.Models.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Notifications
{
    internal class NotificationTypeModelConfig : IEntityTypeConfiguration<NotificationType>
    {
        public void Configure(EntityTypeBuilder<NotificationType> notificationTypeBuilder)
        {
            notificationTypeBuilder.HasIndex(nt => nt.NotificationTypeName).IsUnique();
        }
    }
}