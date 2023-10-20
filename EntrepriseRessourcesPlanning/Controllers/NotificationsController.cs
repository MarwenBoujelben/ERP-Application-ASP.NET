using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntrepriseRessourcesPlanning.Models;
namespace EntrepriseRessourcesPlanning.Controllers
{

    public class NotificationsController : Controller
    {
        private  ContextDB _context;


        public NotificationsController()
        {
            _context = new ContextDB();
        }

        public ActionResult GetNotifications()
        {
            List<Notification> AllowedNotifications = new List<Notification>();
            if (Session["UserCIN"] != null)
            {
                string userCIN = Session["UserCIN"].ToString();
                if (Session["Username"] != null)
                {
                    string userName = Session["Username"].ToString();

                    List<NotificationUser> notificationUsers = _context.NotificationUsers.Where(notUser => notUser.UserID.Equals(userCIN)).ToList();
                    foreach (var notif in notificationUsers)
                    {
                        Notification notification = _context.Notifications.FirstOrDefault(not => (not.NotificationID==notif.NotificationID) && !(not.Username.Equals(userName)));
                        if (notification != null)
                        {
                            AllowedNotifications.Add(notification);
                        }
                    }

                    return Json(AllowedNotifications, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(AllowedNotifications, JsonRequestBehavior.AllowGet);

        }

        // Method to add notifications when a new purchase order is added
        public void AddNotification(string notifAction,string message,string username,int id,string dateTime,string Access)
        {
            Notification notif = new Notification()
            {
                ActionID = id,
                NotificationAction=notifAction,
                Message = message,
                Username=username,
                DateTime = dateTime,
                Access=Access
            };
            _context.Notifications.Add(notif);
            _context.SaveChanges();
            List<User> Users = _context.Users.Include("Accesses").ToList();

            foreach(User user in Users) {
                foreach(AccessClass acc in user.Accesses)
                {
                    if (acc.Acc_Role == message)
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
        
        public ActionResult CountNotifications()
        {
            List<Notification> AllowedNotifications = new List<Notification>();
            if (Session["UserCIN"] != null)
            {
                string userCIN = Session["UserCIN"].ToString();
                if (Session["Username"] != null)
                {
                    string userName = Session["Username"].ToString();

                    List<NotificationUser> notificationUsers = _context.NotificationUsers.Where(notUser => notUser.UserID.Equals(userCIN)).ToList();
                    foreach (var notif in notificationUsers)
                    {
                        Notification notification = _context.Notifications.FirstOrDefault(not => !(not.Username.Equals(userName)));
                        if (notification != null)
                        {
                            AllowedNotifications.Add(notification);
                        }
                    }

                    var numNotifications = AllowedNotifications.Count;
                    return Json(numNotifications, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(0, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DeleteNotificationUser(int notificationId)
        {

            try
            {
                if (Session["UserCIN"] != null)
                {
                    string userCIN = Session["UserCIN"].ToString();

                    // Find the NotificationUser by the provided actionId
                    var notificationUser = _context.NotificationUsers.FirstOrDefault(nu => nu.NotificationID == notificationId && nu.UserID.Equals(userCIN));

                    if (notificationUser != null)
                    {
                        _context.NotificationUsers.Remove(notificationUser);
                        _context.SaveChanges();
                        return Json(new { success = true, message = "NotificationUser deleted successfully." });
                    }
                    else
                    {
                        return Json(new { success = false, message = "NotificationUser not found." });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "An error occurred: "});

                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
        public ActionResult CheckStock()
        {
            try
            {
                List<Product> products = _context.Products.ToList();
                foreach (Product product in products)
                {
                    if (product.Stock == 0)
                    {
                        Notification notification = new Notification()
                        {
                            ActionID = product.ProductID,
                            NotificationAction="Out of Stock",
                            Message = "Product: "+product.Name+" is OUT OF STOCK",
                            DateTime = DateTime.Now.ToString(),
                            Access = "AddingProducts"
                        };
                        Notification notificationInDB = _context.Notifications.FirstOrDefault(notif=>(notif.ActionID==notification.ActionID && notif.Username==null));
                        if (notificationInDB == null)
                        {
                            _context.Notifications.Add(notification);
                            _context.SaveChanges();
                            int lastNotifID = notification.NotificationID;
                            List<User> users = _context.Users.Include("Accesses").ToList();
                            foreach (var user in users)
                            {
                                foreach (var acc in user.Accesses)
                                {
                                    if (acc.Acc_Role == "AddingProducts")
                                    {
                                        NotificationUser notificationUser = new NotificationUser()
                                        {
                                            NotificationID = lastNotifID,
                                            UserID = user.UserCIN
                                        };
                                        _context.NotificationUsers.Add(notificationUser);
                                        _context.SaveChanges();
                                    }
                                }
                            }
                        }
                    }

                }
                return new EmptyResult();
            }
            catch (Exception ex)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }

}