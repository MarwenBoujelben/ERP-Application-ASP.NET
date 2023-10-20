using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class InvoiceViewModel
    {
        public Invoice Invoice { get; set; }
        public List<Provider> Providers { get; set; }
        public List<Receipt> Receipts { get; set; }
        public List<int> SelectedReceiptsIDs { get; set; }
        public decimal TotalAmount { get; set; }

    }
}