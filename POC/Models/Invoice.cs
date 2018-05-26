using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POC.Models
{
    public class Invoice
    {
        [Required]
        [Key]
        public int InvoiceID { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]

        [DisplayName("Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public string Address { get; set; }

        public List<InvoiceLine> InvoiceLines { get; set; }


        public Invoice()
        {
            InvoiceID = 0;
        }

        public String Title
        {
            get
            {
                return InvoiceID != 0 ? "Edit Invoice" : "Add New Invoice";
            }
        }


    }
}