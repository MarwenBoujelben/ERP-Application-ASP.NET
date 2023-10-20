using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int OrderNum { get; set; }
        public DateTime OrderDate { get; set; }
        public int CompanyID { get; set; }
        public int ProviderID { get; set; }
        //public string AdrProvider { get; set; }
        //public string AdrCompany { get; set; }
        //public string PaymentMethod { get; set; }
        //public Invoice Invoice { get; set; }
        public int ReceiptID { get; set; }
        public List<ProductOrder> Products { get; set; }
        public decimal TotalAmount { get; set; }       
    }

    
}