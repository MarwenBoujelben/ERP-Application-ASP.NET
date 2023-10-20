using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntrepriseRessourcesPlanning.Models
{
    public class ProdImages
    {
        [Key]
        public int ProdID { get; set; }
        public byte[] ProdImg { get; set; }
        public int ProductID { get; set; }
    }
}