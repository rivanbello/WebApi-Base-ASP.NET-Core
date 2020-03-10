using Segfy.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Segfy.Core.Business.Interfaces.Arguments
{
    public interface INotifier
    {
        bool HasNotifications();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
