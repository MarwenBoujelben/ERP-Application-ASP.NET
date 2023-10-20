using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string PaymentMethod { get; set; }
        public int ProviderID { get; set; }
        public int CompanyID { get; set; }
        //public string AdrCompany { get; set; }
        public ICollection<int> ReceiptsIDs { get; set; }
        public decimal TotalAmount { get; set; }
       
    }
}