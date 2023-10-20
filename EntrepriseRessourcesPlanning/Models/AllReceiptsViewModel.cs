using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class AllReceiptsViewModel
    {
        public List<Receipt> Receipts { get; set; }
        public List<Provider> Providers { get; set; }
    }
}