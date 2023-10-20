using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class AllPurchaseViewModel
    {
        public List<PurchaseOrder> PurchaseOrders { get; set; }
        public List<Provider> Providers { get; set; }
    }
}