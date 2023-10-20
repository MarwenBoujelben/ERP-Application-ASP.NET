using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class ReceiptViewModel
    {
        public Receipt Receipt { get; set; }
        //public DateTime ReceptionDate { get; set; }
        //public int ProviderID { get; set; }

        public List<Provider> Providers { get; set; }
        // Add other properties as needed for the receipt view

        // Property to hold the selected PurchaseOrder IDs from checkboxes
        public List<int> SelectedPurchaseOrderIDs { get; set; }

        // Collection to hold all available PurchaseOrders (for the checkboxes)
        public List<PurchaseOrder> PurchaseOrders { get; set; }

        public decimal TotalAmount { get; set; }
    }

}