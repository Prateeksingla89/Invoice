using POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using POC.ViewModel;
using System.Data.Entity.Validation;

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
            ViewBag.productDetails = _context.Products.ToList();
            return View(allDetails);

        }

        // GET: Invoice
        public ActionResult Edit(int invoiceID)
        {
            var allDetails = _context.Invoices.SingleOrDefault(m => m.InvoiceID == invoiceID);
            var viewModel = new InvoiceViewModel
            {
                InvoiceNumber=allDetails.InvoiceNumber,
                CustomerName=allDetails.CustomerName,
                CustomerDescription = allDetails.CustomerDescription,
                Address =allDetails.Address,
                InvoiceDate=allDetails.InvoiceDate,
                InvoiceID=allDetails.InvoiceID,
                productsList = _context.Products.ToList(),                
                InvoiceLines = _context.InvoiceLines.Where(m => m.InvoiceID == invoiceID).ToList()
            };
            return View("InvoiceForm", viewModel);
        }


        // GET: Invoice
        public ActionResult InvoiceForm()
        {
         
            var viewModel = new InvoiceViewModel
            {
                
                InvoiceLines =/*_context.InvoiceLines.ToList(),*/ new List<InvoiceLine>(),
                productsList =_context.Products.ToList()

            };
            return View("InvoiceForm", viewModel);
        }

        // GET: Invoice
        public JsonResult getTax(int ProductId)
        {

            var productTax = _context.Products.SingleOrDefault(m => m.ProductId == ProductId);

            return Json(productTax, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Invoice invoices)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new InvoiceViewModel
                {
                    productsList = _context.Products.ToList(),
                    InvoiceLines = new List<InvoiceLine>()
                };
                return View("InvoiceForm", viewModel);
            }
            if (invoices.InvoiceID == 0)
            {
                _context.Invoices.Add(invoices);
            }
            else
            {
                var invoiceInDb = _context.Invoices
                    .Include(m=>m.InvoiceLines)
                    .Single(i => i.InvoiceID == invoices.InvoiceID);

                invoiceInDb.InvoiceNumber = invoices.InvoiceNumber;
                invoiceInDb.InvoiceDate = invoices.InvoiceDate;
                invoiceInDb.CustomerName = invoices.CustomerName;
                invoiceInDb.CustomerName = invoices.CustomerDescription;
                invoiceInDb.Address = invoices.Address;
                invoiceInDb.InvoiceLines = invoices.InvoiceLines;
               
            }
            try
            {

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
              
            return RedirectToAction("Index");
        }


    }
}