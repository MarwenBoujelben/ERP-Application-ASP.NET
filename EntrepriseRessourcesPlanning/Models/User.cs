using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class User
    {
        [Key]
        public string UserCIN { get; set; }
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public  ICollection<AccessClass> Accesses { get; set; }
    }
}