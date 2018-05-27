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
        [MaxLength(250)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

    }
}