using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class ProductOrder
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProductID { get; set; }
        public string Description { get; set; }
        public decimal UnitPriceHT { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPriceHT { get; set; }
        public decimal TVA { get; set; }
        public decimal TotalTTC { get; set; }
        public PurchaseOrder Purchase { get; set; }
        public string Category { get; set; }
        //public Quotation Quotation { get; set; }

    }
}