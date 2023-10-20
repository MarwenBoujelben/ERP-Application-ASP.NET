using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class Provider
    {
        [Key]
        public int ProviderID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        //public ICollection<Product> Products { get; set; }


    }
}