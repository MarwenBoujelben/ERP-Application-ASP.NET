using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class NotificationUser
    {
        [Key]
        public int ID { get; set; }
        public int NotificationID { get; set; }
        public string UserID { get; set; } 
    }
}