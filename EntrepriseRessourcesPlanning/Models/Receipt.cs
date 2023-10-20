using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class Receipt
    {
        [Key]
        public int ReceiptID { get; set; }
        public DateTime ReceptionDate { get; set; }
        public int ProviderID { get; set; }
        public int CompanyID { get; set; }
        //public string AdrCompany { get; set; }
        //public bool IsReceived { get; set; }
        public ICollection<int> PurchaseOrdersIDs { get; set; }
        public int InvoiceID { get; set; }
        public decimal TotalAmount { get; set; } 
    }


}