using EntrepriseRessourcesPlanning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Service
{
    public class Services
    {
        private readonly ContextDB _context;

        public Services()
        {
            _context = new ContextDB();

        }
        public void AddNotification(int addedProductId,string notificationAction, string message, string username, string datetime, string access)
        {
            Notification notif = new Notification()
            {
                ActionID = addedProductId,
                NotificationAction=notificationAction,
                Message = message,
                Username = username,
                DateTime = datetime,
                Access = access
            };
            _context.Notifications.Add(notif);
            _context.SaveChanges();
            List<User> Users = _context.Users.Include("Accesses").Where(user=>user.Username.ToUpper()!=username).ToList();

            foreach (User user in Users)
            {
                
                foreach (AccessClass acc in user.Accesses)
                {
                    if (acc.Acc_Role == access)
                    {
                        NotificationUser notificationUser = new NotificationUser()
                        {
                            UserID = user.UserCIN,
                            NotificationID = notif.NotificationID
                        };
                        _context.NotificationUsers.Add(notificationUser);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}