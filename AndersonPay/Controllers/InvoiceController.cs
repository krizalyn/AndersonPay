using AndersonPayFunction;
using AndersonPayModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndersonPay.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        private IFInvoice _iFInvoice;
        public InvoiceController()
        {
            _iFInvoice = new FInvoice();
        }
        // Create new Invoice
        #region Create 
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Invoice());
        }

        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            invoice = _iFInvoice.Create(invoice);
            return RedirectToAction("Index");
            //, new { id = invoice.InvoiceId }
        }
        #endregion
        public ActionResult InvoiceSummary()
        {
            return PartialView();
        }
        // Read list of invoices

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFInvoice.Read());
        }

        #endregion

        //UPDATE CLIENT
        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFInvoice.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Invoice invoice)
        {
            invoice = _iFInvoice.Update(invoice);
            return RedirectToAction("Index");

        }
        #endregion

        //Delete Invoice
        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {

            _iFInvoice.Delete(id);
            return Json(string.Empty);

        }
        #endregion
    }
    // asdasd
}