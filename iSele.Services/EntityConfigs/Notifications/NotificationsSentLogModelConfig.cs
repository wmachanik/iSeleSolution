using iSele.Models.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Notifications
{
    internal class NotificationsSentLogModelConfig : IEntityTypeConfiguration<NotificationsSentLog>
    {
        public void Configure(EntityTypeBuilder<NotificationsSentLog> notificationsSentLogBuilder)
        {
            notificationsSentLogBuilder.HasIndex(ns => ns.DateSentNotification);
            notificationsSentLogBuilder.HasOne(ns => ns.Customer)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);
            notificationsSentLogBuilder.HasOne(ns=>ns.NotificationType)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}