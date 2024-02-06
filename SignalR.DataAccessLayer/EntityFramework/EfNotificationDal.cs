using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly SignalRContext _context;
        public EfNotificationDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            return _context.Notifications.Where(x => x.Status == false).ToList();
        }


        public int NotificationCountByStatusFalse()
        {
            var notificationCount = _context.Notifications.Where(x => x.Status == false).Count();
            return notificationCount;
        }

        // Bildiirimlerin henüz okunmamış olarak işaretlenmesi.
        public void NotificationStatusChangeToFalse(int id)
        {
            var notification = _context.Notifications.Find(id);

            if (notification != null && notification.Status)
            {
                notification.Status = false;
                _context.SaveChanges();
            }
        }

        // Bildiirimlerin okunmuş olarak işaretlenmesi.
        public void NotificationStatusChangeToTrue(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification != null)
            {
                if (!notification.Status)
                {
                    notification.Status = true;
                }
                else
                {
                    notification.Status = false;
                }

                _context.SaveChanges();
            }
        }
    }
}
