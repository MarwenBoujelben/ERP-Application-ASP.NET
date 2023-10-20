using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class AllInvoicesViewModel
    {
        public List<Invoice> Invoices { get; set; }
        public List<Provider> Providers { get; set; }
    }
}