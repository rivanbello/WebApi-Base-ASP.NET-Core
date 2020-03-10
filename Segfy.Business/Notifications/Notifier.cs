using Segfy.Core.Business.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segfy.Core.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier(List<Notification> notification)
        {
            _notifications = notification;
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
