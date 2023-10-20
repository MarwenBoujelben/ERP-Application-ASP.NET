using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class Company
    {
        [Key]
        public int RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public decimal TurnOver { get; set; }
        //public ICollection<Product> Products { get; set; }
        //public ICollection<Receipt> Receipts { get; set; }
        //public ICollection<Quotation> Quotations { get; set; }
        //public ICollection<ProductOrder> ProductOrders { get; set; }



    }
}