using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using POC.Models;

namespace POC.ViewModel
{
    public class InvoiceViewModel
    {


       // public List<InvoiceLine> invoiceLines { get; set; }
        public List<Product> products { get; set; }


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

      //  public List<Product> productsList { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        public InvoiceViewModel()
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


        public InvoiceViewModel(Invoice invoice)
        {
            InvoiceID = invoice.InvoiceID;
            InvoiceNumber = invoice.InvoiceNumber;
            CustomerName = invoice.CustomerName;
            InvoiceDate = DateTime.Now;
            Address = invoice.Address;
            //ProductId = invoice.InvoiceLines[0].ProductId;
            InvoiceLines = new List<InvoiceLine>();
        }
    }
}