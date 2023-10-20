using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class PurchaseOrderViewModel
    {
        public PurchaseOrder PurchaseOrder { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public List<Provider> Providers { get; set; } // Add this property
    }
}