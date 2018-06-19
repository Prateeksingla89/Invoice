using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POC.Models
{
    public class InvoiceLine
    {
        [Key]
        [Required]
        public int InvoiceLineId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Value { get; set; }


        [ForeignKey("ParentInvoice")]
        public int InvoiceID { get; set; }

        public Invoice ParentInvoice { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }


    }
}