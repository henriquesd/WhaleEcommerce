using System.Collections.Generic;
using WhaleEcommerce.Domain.Notifications;

namespace WhaleEcommerce.Domain.Interfaces
{
    public interface INotifyer
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}