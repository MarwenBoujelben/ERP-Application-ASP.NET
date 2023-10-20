using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class AccessClass
    {
        
        [Key]
        public int AccessId { get; set; }

        public string Acc_Role { get; set; }
        public ICollection<User> Users { get; set; }
    }
}