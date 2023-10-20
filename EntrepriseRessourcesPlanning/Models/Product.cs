using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Category { get; set; }
        public Company Company { get; set; }
        //public List<byte[]> ProdImage { get; set; }
        public int NumImages { get; set; }
        //public ICollection<Provider> Providers { get; set; }

    }
    //public class ProductImage
    //{
        //[Key]
        //public int ProductImageID { get; set; }
        //public byte[] ImageData { get; set; }
        //public Product Product { get; set; }
    //}
}