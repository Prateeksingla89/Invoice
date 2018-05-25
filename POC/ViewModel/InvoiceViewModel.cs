using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POC.Models;

namespace POC.ViewModel
{
    public class InvoiceViewModel
    {


        public List<InvoiceLine> invoiceLines { get; set; }
        public Invoice invoices { get; set; }


        public InvoiceViewModel()
        {
            invoices.InvoiceID = 0;
        }

        public String Title
        {
            get
            {
                return invoices.InvoiceID != 0 ? "Edit Invoice" : "Add New Invoice";
            }
        }

    }
}