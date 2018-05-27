using POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using POC.ViewModel;



namespace POC.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Invoice
        public ActionResult Index()
        {
            var allDetails = _context.Invoices.Include(m => m.InvoiceLines).ToList();
            return View(allDetails);

        }

        // GET: Invoice
        public ActionResult Edit(int invoiceID)
        {
            var allDetails = _context.Invoices
                            .Include(m=>m.InvoiceLines)
                            .Where(m => m.InvoiceID == invoiceID)
                            .FirstOrDefault();
            int productId = _context.InvoiceLines.Include(m => m.Product).Select(p => p.ProductId).FirstOrDefault();

            var product = _context.Products.Where(m => m.ProductId == productId).ToList();

            var viewModel = new InvoiceViewModel(allDetails)
            {

                products= product,
                InvoiceLines = _context.InvoiceLines.Where(m => m.InvoiceID == invoiceID).ToList()//new List<InvoiceLine>()
                //ProductId = _context.InvoiceLines.Where(m => m.InvoiceID == invoiceID).Select(m => m.Product.ProductId).FirstOrDefault()


            };
            return View("InvoiceForm", viewModel);
        }


        // GET: Invoice
        public ActionResult InvoiceForm()
        {
            // var InvoiceLines = _context.InvoiceLines.ToList();
         
            var viewModel = new InvoiceViewModel
            {
                products = _context.Products.ToList(),
                InvoiceLines = _context.InvoiceLines.ToList()//new List<InvoiceLine>()

            };
            return View("InvoiceForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Invoice invoices)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new InvoiceViewModel(invoices)
                {
                    products = _context.Products.ToList()
                    
                    
                };
                return View("InvoiceForm", viewModel);
            }
            if (invoices.InvoiceID == 0)
            {
                Invoice invoiceInDb = new Invoice
                {
                    InvoiceNumber = invoices.InvoiceNumber,
                    InvoiceDate = DateTime.Now,
                    CustomerName=invoices.CustomerName,
                    Address=invoices.Address,
                    InvoiceLines = invoices.InvoiceLines
                    
                };
                _context.Invoices.Add(invoiceInDb);
            }
            else
            {
                var invoiceInDb = _context.Invoices
                    .Include(m=>m.InvoiceLines)
                    .Single(i => i.InvoiceID == invoices.InvoiceID);

                invoiceInDb.InvoiceNumber = invoices.InvoiceNumber;
                invoiceInDb.InvoiceDate = invoices.InvoiceDate;
                invoiceInDb.CustomerName = invoices.CustomerName;
                invoiceInDb.Address = invoices.Address;
               
                if (invoiceInDb.InvoiceLines.Count > 0)
                {
                    int i = 0;
                    foreach (var item in invoiceInDb.InvoiceLines)
                    {
                        item.ItemName = invoices.InvoiceLines[i].ItemName;
                        item.ItemDescription = invoices.InvoiceLines[i].ItemDescription;
                        item.Quantity = invoices.InvoiceLines[i].Quantity;
                        item.Value = invoices.InvoiceLines[i].Value;
                        item.ProductId = invoices.InvoiceLines[i].ProductId;
                        i++;
                    }
                }

            }
            _context.SaveChanges();
            return RedirectToAction("InvoiceForm");
        }


    }
}