using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POC.Models
{
    public class Product
    {
        [Required]
        [Key]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Required]
        public int GstTax { get; set; }
    }
}