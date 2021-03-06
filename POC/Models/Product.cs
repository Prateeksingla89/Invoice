﻿using System;
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

        [MaxLength(500)]
        [DisplayName("Product Discription")]
        public string Discription { get; set; }

        [DisplayName("Product Price")]
        public decimal price { get; set; }

        [Required]
        public int GstTax { get; set; }
    }
}