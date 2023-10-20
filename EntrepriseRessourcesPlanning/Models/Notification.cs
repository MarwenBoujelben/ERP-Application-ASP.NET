using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public string NotificationAction { get; set; }
        public int ActionID { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string DateTime { get; set; }
        public string Access { get; set; }

    }
}