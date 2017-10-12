using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AndersonPay.Models;
using AndersonPay.Models.InvoiceContext;
using PagedList;
using Rotativa;
using System.IO;
using AndersonPay.Models.SearchArchive;
using AndersonPay.Models.Manpower;
using Newtonsoft.Json;

namespace AndersonPay.Controllers
{
    public class AndersonPayController : Controller
    {
        private InvoiceContext db = new InvoiceContext();

        //int? page: question mark means can be null. page = number of pages (Index line 174)
        public ActionResult Index(string sortBy, int? page, string filterBy, int? id, string status, string searchBy, string search)
        {
            //Search Function
            if (!String.IsNullOrEmpty(search))
            {
                return View(db.invoices.Where(x => x.CompanyName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 30));
            }


            //db inculudes the company table in database
            var invoices = db.invoices.Include(i => i.Company);
            //line 29 - 50: All functions about Sorting data in View(Index).
            invoices = invoices.OrderByDescending(x => x.invoiceId);
            ViewBag.SortDateDesc = "Date desc";
            ViewBag.SortDateAsc = "Date";
            ViewBag.SortDueDateDesc = "Due Date desc";
            ViewBag.SortDueDateAsc = "Due Date";
            ViewBag.SortTotalDesc = "Total desc";
            ViewBag.SortTotalAsc = "Total";
            ViewBag.SortNameAsc = "Name Asc";
            ViewBag.SortNameDsc = "Name Dsc";
            ViewBag.SortDateToday = "Today";
            ViewBag.SortDateThisWeek = "This Week";
            ViewBag.SortDateThisMonth = "This Month";
            ViewBag.SortDateThisYear = "This Year";
            //Declaration of Dateranges for Comparing
            DateTime FromDate = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
            DateTime UptoDate = FromDate;
            // remove time from Today
            DateTime Today = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
            ViewBag.Header = sortBy;
            if (sortBy != null)
            {
                ViewBag.Header = sortBy;
            }
            else if (filterBy != null)
            {
                ViewBag.Header = filterBy;
            }
            else
            {
                ViewBag.Header = "Invoices";
            }
            switch (sortBy)
            {
                case "Today":
                    //return View(db.invoices.Where(x => x.Date == Today).ToList().ToPagedList(page ?? 1, 30));
                    invoices = db.invoices.Where(x => x.Date == Today);
                    break;
                case "This Week":
                    //switch inside a switch, to improve the time of execution
                    //Week Range Function                 
                    switch (DateTime.Now.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            UptoDate = UptoDate.AddDays(6);
                            break;
                        case "Monday":
                            FromDate = FromDate.AddDays(-1);
                            UptoDate = UptoDate.AddDays(5);
                            break;
                        case "Tuesday":
                            FromDate = FromDate.AddDays(-2);
                            UptoDate = UptoDate.AddDays(4);
                            break;
                        case "Wednesday":
                            FromDate = FromDate.AddDays(-3);
                            UptoDate = UptoDate.AddDays(3);
                            break;
                        case "Thursday":
                            FromDate = FromDate.AddDays(-4);
                            UptoDate = UptoDate.AddDays(2);
                            break;
                        case "Friday":
                            FromDate = FromDate.AddDays(-5);
                            UptoDate = UptoDate.AddDays(1);
                            break;
                        case "Saturday":
                            FromDate = FromDate.AddDays(-6);
                            break;
                    }
                    //Week Range Function End
                    //return View(db.invoices.Where(x => x.Date >= FromDate && x.Date <= UptoDate).ToList().ToPagedList(page ?? 1, 30));
                    invoices = invoices.Where(x => x.Date >= FromDate && x.Date <= UptoDate);
                    break;
                case "This Month":
                    Today = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM"));
                    FromDate = Today;
                    UptoDate = Convert.ToDateTime(Today.AddMonths(1).ToString("yyyy/MM"));
                    invoices = db.invoices.Where(x => x.Date >= FromDate && x.Date < UptoDate);
                    break;
                // return View(db.invoices.Where(x => x.Date >= FromDate && x.Date < UptoDate).ToList().ToPagedList(page ?? 1, 30));
                case "This Year":
                    //return View(db.invoices.Where(x => x.Date.Year == DateTime.Now.Year).ToList().ToPagedList(page ?? 1, 30));
                    invoices = db.invoices.Where(x => x.Date.Year == DateTime.Now.Year);
                    break;
                case "Date desc":
                    invoices = invoices.OrderByDescending(x => x.Date);
                    break;
                case "Total desc":
                    invoices = invoices.OrderByDescending(x => x.Total);
                    break;
                case "Date":
                    invoices = invoices.OrderBy(x => x.Date);
                    break;
                case "Due Date":
                    invoices = invoices.OrderBy(x => x.DueDate);
                    break;
                case "Due Date desc":
                    invoices = invoices.OrderByDescending(x => x.DueDate);
                    break;
                case "Total":
                    invoices = invoices.OrderBy(x => x.Total);
                    break;
                case "Name Asc":
                    invoices = invoices.OrderBy(x => x.CompanyName);
                    break;
                case "Name Dsc":
                    invoices = invoices.OrderByDescending(x => x.CompanyName);
                    break;
            }

            ViewBag.StatusOverdue = "Overdue";
            ViewBag.StatusPending = "Pending";
            ViewBag.StatusOnHold = "On Hold";
            ViewBag.StatusCanceled = "Canceled";
            ViewBag.StatusPaid = "Paid";
            ViewBag.CurrencyPeso = "Peso";
            ViewBag.CurrencyPeso = "Dollar";
            ViewBag.CurrencyPeso = "UK Pounds";


            switch (status)
            {
                case "Overdue":
                    invoice invoiceod = db.invoices.Find(id);
                    invoiceod.Status = "Overdue";
                    db.SaveChanges();
                    break;
                case "Pending":
                    invoice invoicep = db.invoices.Find(id);
                    invoicep.Status = "Pending";
                    db.SaveChanges();
                    break;
                case "On Hold":
                    invoice invoiceoh = db.invoices.Find(id);
                    invoiceoh.Status = "On Hold";
                    db.SaveChanges();
                    break;
                case "Canceled":
                    invoice invoicec = db.invoices.Find(id);
                    invoicec.Status = "Canceled";
                    db.SaveChanges();
                    break;
                case "Paid":
                    invoice invoicepd = db.invoices.Find(id);
                    invoicepd.Status = "Paid";
                    db.SaveChanges();
                    break;

            }


            //FILTER BY STATUS
            if (filterBy == "Pending")
            {
                //return View(db.invoices.Where(x => x.Status == "Pending").ToList().ToPagedList(page ?? 1, 30));
                invoices = db.invoices.Where(x => x.Status == "Pending");
            }
            else if (filterBy == "Overdue")
            {
                //return View(db.invoices.Where(x => x.Status == "Overdue").ToList().ToPagedList(page ?? 1, 30));
                invoices = db.invoices.Where(x => x.Status == "Overdue");
            }
            else if (filterBy == "Paid")
            {
                //return View(db.invoices.Where(x => x.Status == "Paid").ToList().ToPagedList(page ?? 1, 30));
                invoices = db.invoices.Where(x => x.Status == "Paid");
            }
            else if (filterBy == "On Hold")
            {
                //return View(db.invoices.Where(x => x.Status == "On Hold").ToList().ToPagedList(page ?? 1, 30));
                invoices = db.invoices.Where(x => x.Status == "On Hold");
            }
            else if (filterBy == "Canceled")
            {
                //return View(db.invoices.Where(x => x.Status == "Canceled").ToList().ToPagedList(page ?? 1, 30));
                invoices = db.invoices.Where(x => x.Status == "Canceled");
            }

            //FILTER BY CURRENCY
            else if (filterBy == "Peso")
            {
                //return View(db.invoices.Where(c => c.Currency == "Peso").ToList().ToPagedList(page ?? 1, 15));
                invoices = db.invoices.Where(x => x.Currency == "Peso");
            }
            else if (filterBy == "Dollar")
            {
                invoices = db.invoices.Where(x => x.Currency == "Dollar");
                //return View(db.invoices.Where(c => c.Currency == "Dollar").ToList().ToPagedList(page ?? 1, 15));
            }
            else if (filterBy == "UK Pounds")
            {
                invoices = db.invoices.Where(x => x.Currency == "UK Pounds");
                // return View(db.invoices.Where(c => c.Currency == "UK Pounds").ToList().ToPagedList(page ?? 1, 15));
            }
            //else
            //{
            //    //invoices are in list. Kaya mag kaka error sa Index pag hindi @foreach ung ginamit.
            //    //return View(invoices.ToList().ToPagedList(page ?? 1, 30));
            //    return View(invoices.ToList());
            //}
            if (db.invoices.Count() == 0) return View(invoices.ToList().ToPagedList(page ?? 1, 1));
            else return View(invoices.ToList().ToPagedList(page ?? 1, db.invoices.Count()));

        }

        public ActionResult DeletedInvoice(int? page, int? id)
        {
            //invoices are in list. Kaya mag kaka error sa Index pag hindi @foreach ung ginamit.
            return View(db.invoices.ToList().ToPagedList(page ?? 1, 30));
        }
        public ActionResult RestoreInvoice(int id)
        {
            db.invoices.Find(id).Deleted = false;
            db.SaveChanges();
            return RedirectToAction("DeletedInvoice");
        }

        public ActionResult DeleteInvoice(int id)
        {
            db.invoices.Remove(db.invoices.Find(id));
            db.SaveChanges();
            return RedirectToAction("DeletedInvoice");
        }
        /*GENERATE PDF FUNCTION */
        public ActionResult ExportPDF(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoice invoice = db.invoices.Find(id);

            var idHolder = id.ToString();

            return new ActionAsPdf("printPDF", new { id = id })
            {
                FileName = "INV-00" + idHolder + " - ClientCode.pdf"
            };
        }
       
        //This will print PDF
        public ActionResult PrintPDF(int? id)
        {
            invoice invoice = db.invoices.Find(id);
            return View(invoice);
        }

        // GET: invoice/Create
        [HttpGet]
        public ActionResult CreateInvoice()
        {
            var typesOfService = db.typeofservices;
            ViewBag.CompanyName = new SelectList(db.companies, "CompanyName", "CompanyName");
            //ViewBag.TypeOfService = new SelectList(typesOfService, "NameOfService", "NameOfService");
            //ViewBag.TypeOfServices = JsonConvert.SerializeObject(typesOfService.ToList());
            return View(db.invoices.Create());

        }

        [HttpPost]
        public JsonResult TypeOfServices()
        {
            using (var invoiceContext = new InvoiceContext())
            {
                var typeOfServices = invoiceContext.typeofservices.ToList();
                return Json(typeOfServices);
            }

        }
        
        [HttpPost]
        public ActionResult CreateInvoice(string Submit, string Comments, invoice invoice, MultipleService multipleServices)      
        {

            multipleServices.invoiceId = invoice.invoiceId;
            invoice.Multiple = true;
            invoice.TypeOfService = "Multiple";
            invoice.Description = "Multiple Services";
            invoice.Amount = multipleServices.SubTotal;
            multipleServices.NameOfService = invoice.TypeOfService;
            
            //Converts everything from string to their definite var type
            var lfHldr = Convert.ToDecimal(invoice.LateFee);

            //amount
            //invoice.Amount = rateHldr * qtyHldr;
            //government tax


            //withholding tax
            //JEV WAS HERE NYAHAHA
            if (invoice.GovernmentTax == 12)
            {
                decimal x = multipleServices.SubTotal * invoice.GovernmentTax;
                invoice.gtholder = 12;
                decimal govtax = x / 100;
                invoice.GovernmentTax = govtax;
                invoice.WithholdingTax = 0;
                decimal y = invoice.Amount * invoice.WithholdingTax;
                invoice.whtholder = invoice.WithholdingTax;
                decimal whtax = y / 100;
                invoice.WithholdingTax = whtax;
            }

            if (invoice.WithholdingTax == 1)
            {

                invoice.WithholdingTax = 1;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = wttax;
                Convert.ToDouble(invoice.Amount);
                decimal y = multipleServices.SubTotal * wttax;
                invoice.WithholdingTax = y;

                
            }
            else if (invoice.WithholdingTax == 2)
            {


                invoice.WithholdingTax = 2;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = invoice.WithholdingTax;
                decimal y = invoice.Amount * wttax;
                invoice.WithholdingTax = y;



            }
            else if (invoice.WithholdingTax == 5)
            {

              
                invoice.WithholdingTax = 5;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = wttax;
                Convert.ToDouble(invoice.Amount);
                decimal y = invoice.Amount * wttax;
                invoice.WithholdingTax = y;



            }
     

            //latefee
            decimal q = invoice.Amount * lfHldr;
            invoice.lfholder = lfHldr;
            decimal latefee = q / 100;
            lfHldr = latefee;
            invoice.LateFee = Convert.ToString(lfHldr);
            invoice.Comments = Comments;

            invoice.totalTax = invoice.gtholder + invoice.whtholder + invoice.lfholder;

            invoice.Status = "Pending";

            if (invoice.TypeOfService != null && invoice.Quantity != null && invoice.Rate != null)
            {
                if (ModelState.IsValid)
                {
                    switch (Submit)
                    {
                        case "Preview":
                            return RedirectToAction("PreviewInvoice", invoice);

                        default:
                            db.invoices.Add(invoice);
                            db.SaveChanges();
                            if (invoice.TypeOfService == "Multiple")
                            {
                                return RedirectToAction("Submit");
                            }
                            return RedirectToAction("EmailRedirect", new { id = invoice.invoiceId });
                    }
                }
            }
            ViewBag.CompanyName = new SelectList(db.companies, "CompanyName", "CompanyName", invoice.CompanyName);
            ViewBag.TypeOfService = new SelectList(db.typeofservices, "typeofserviceId", "NameOfService", invoice.TypeOfService);
            ViewBag.MultipleServices = new SelectList(db.MultipleServices, "typeofserviceId", "NameOfService", invoice.multipleServices);
            //return View(invoice);
            return Json(invoice);
        }

        [HttpGet]
        public ActionResult PreviewInvoice(invoice invoice)
        {
            return View(invoice);
        }

        
        [HttpPost]
        public ActionResult PreviewInvoice(invoice invoice, int? id, string Preview, MultipleService multipleServices)
        {
            multipleServices.invoiceId = invoice.invoiceId;
            invoice.Multiple = true;
            invoice.TypeOfService = "Multiple";
            invoice.Description = "MultipleServices";
            invoice.Amount = multipleServices.SubTotal;
            multipleServices.NameOfService = invoice.TypeOfService;
            var lfHldr = Convert.ToDecimal(invoice.LateFee);

            
            //government tax


            //withholding tax
            //JEV WAS HERE NYAHAHA
            if (invoice.GovernmentTax == 12)
            {
                decimal x = multipleServices.SubTotal * invoice.GovernmentTax;
                invoice.gtholder = 12;
                decimal govtax = x / 100;
                invoice.GovernmentTax = govtax;
                invoice.WithholdingTax = 0;
                decimal y = invoice.Amount * invoice.WithholdingTax;
                invoice.whtholder = invoice.WithholdingTax;
                decimal whtax = y / 100;
                invoice.WithholdingTax = whtax;
            }

            if (invoice.WithholdingTax == 1)
            {

                invoice.WithholdingTax = 1;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = wttax;
                Convert.ToDouble(invoice.Amount);
                decimal y = multipleServices.SubTotal * wttax;
                invoice.WithholdingTax = y;


            }
            else if (invoice.WithholdingTax == 2)
            {

                invoice.WithholdingTax = 2;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = invoice.WithholdingTax;
                decimal y = invoice.Amount * wttax;
                invoice.WithholdingTax = y;

            }
            else if (invoice.WithholdingTax == 5)
            {


                invoice.WithholdingTax = 5;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = wttax;
                Convert.ToDouble(invoice.Amount);
                decimal y = invoice.Amount * wttax;
                invoice.WithholdingTax = y;



            }
            else
            {
                
                invoice.WithholdingTax = 0;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = wttax;
                Convert.ToDouble(invoice.Amount);
                decimal y = invoice.Amount * wttax;
                invoice.WithholdingTax = y;

            }


            //latefee
            decimal q = invoice.Amount * lfHldr;
            invoice.lfholder = lfHldr;
            decimal latefee = q / 100;
            lfHldr = latefee;
            invoice.LateFee = Convert.ToString(lfHldr);



            invoice.totalTax = invoice.gtholder + invoice.whtholder + invoice.lfholder;
            invoice.Total = invoice.Amount + invoice.GovernmentTax + invoice.WithholdingTax + latefee;
            invoice.Status = "Pending";

            if (ModelState.IsValid)
            {
                switch (Preview)
                {
                    case "Preview":
                        return RedirectToAction("PreviewInvoice", invoice);

                    default:
                        db.invoices.Add(invoice);                    
                        db.SaveChanges();
                        db.invoices.Find(id);
                        return RedirectToAction("EmailRedirect", new { id = invoice.invoiceId });
                }
            }
            //return View(invoice);
            return Json(invoice);
        }
        // GET: invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoice invoice = db.invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return PartialView(invoice);
        }

        // POST: invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //invoice invoice = db.invoices.Find(id);
            //db.invoices.Remove(invoice);
            //db.SaveChanges();
            db.invoices.Find(id).Deleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ///////////////////////////////////////////////////////////////////////////////MAINTENANCE/////////////////////////////////////////////////////////////////
        public ActionResult Archive(string search, int? page)
        {
            var results = from s in db.Archives select s;
            return View(results.Where(x => x.Name.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 30));
        }

        //
        // GET: /Support/Create

        public ActionResult CreateArchive()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArchive(Archive support)
        {
            if (ModelState.IsValid)
            {
                List<FileDetail> fileDetails = new List<FileDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileDetails.Add(fileDetail);

                        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                support.FileDetails = fileDetails;
                db.Archives.Add(support);
                db.SaveChanges();
                return RedirectToAction("Archive");
            }

            return View(support);
        }



        //
        // GET: /Support/Edit/5

        public ActionResult EditArchive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archive support = db.Archives.Include(s => s.FileDetails).SingleOrDefault(x => x.SupportId == id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }


        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/App_Data/Uploads/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }



        //
        // POST: /Support/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArchive(Archive support)
        {
            if (ModelState.IsValid)
            {

                //New Files
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            SupportId = support.SupportId
                        };
                        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileDetail).State = EntityState.Added;
                    }
                }

                db.Entry(support).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Archive");
            }
            return View(support);
        }



        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                FileDetail fileDetail = db.FileDetails.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileDetails.Remove(fileDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/App_Data/Uploads/"), fileDetail.Id + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }


        }





        //
        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult DeleteArchive(int id)
        {
            try
            {
                Archive support = db.Archives.Find(id);
                if (support == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in support.FileDetails)
                {
                    String path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.Archives.Remove(support);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        //////////MANPOWER//////////
        public ActionResult Manpower(string search, int? page)
        {
            var results = from s in db.Manpowers select s;
            return View(results.Where(x => x.Name.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 30));
        }

        //
        // GET: /Support/Create

        public ActionResult CreateManpower()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateManpower(Manpower verify)
        {
            if (ModelState.IsValid)
            {
                List<ManpowerFile> manpowerFiles = new List<ManpowerFile>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var Filename = Path.GetFileName(file.FileName);
                        ManpowerFile manpowerFile = new ManpowerFile()
                        {
                            Filename = Filename,
                            Annex = Path.GetExtension(Filename),
                            Id = Guid.NewGuid()
                        };
                        manpowerFiles.Add(manpowerFile);

                        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads/"), manpowerFile.Id + manpowerFile.Annex);
                        file.SaveAs(path);
                    }
                }

                verify.ManpowerFiles = manpowerFiles;
                db.Manpowers.Add(verify);
                db.SaveChanges();
                return RedirectToAction("Manpower");
            }

            return View(verify);
        }

        //
        // GET: /Support/Edit/5

        public ActionResult EditManpower(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manpower verify = db.Manpowers.Include(s => s.ManpowerFiles).SingleOrDefault(x => x.ManpowerId == id);
            if (verify == null)
            {
                return HttpNotFound();
            }
            return View(verify);
        }


        //
        // POST: /Support/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditManpower(Manpower verify)
        {
            if (ModelState.IsValid)
            {

                //New Files
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        ManpowerFile manpowerFile = new ManpowerFile()
                        {
                            Filename = fileName,
                            Annex = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            ManpowerId = verify.ManpowerId
                        };
                        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads/"), manpowerFile.Id + manpowerFile.Annex);
                        file.SaveAs(path);

                        db.Entry(manpowerFile).State = EntityState.Added;
                    }
                }

                db.Entry(verify).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manpower");
            }
            return View(verify);
        }



        [HttpPost]
        public JsonResult DeleteFiles(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                ManpowerFile manpowerFile = db.ManpowerFiles.Find(guid);
                if (manpowerFile == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.ManpowerFiles.Remove(manpowerFile);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/App_Data/Uploads/"), manpowerFile.Id + manpowerFile.Annex);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }


        }





        //
        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult DeleteManpower(int id)
        {
            try
            {
                Manpower verify = db.Manpowers.Find(id);
                if (verify == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in verify.ManpowerFiles)
                {
                    String path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), item.Id + item.Annex);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.Manpowers.Remove(verify);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        // About View //
        public ActionResult About()
        {

            return View();
        }

        // Report View //
        public ActionResult Reports()
        {

            return View();
        }

        // Database View //
        public ActionResult Database()
        {

            return View();
        }

        // Maintenance View //
        public ActionResult Maintenance()
        {

            return View();
        }


        // -------------- //
        public ActionResult EmailRedirect()
        {

            return View();

        }

        public ActionResult EmailSent()
        {

            return View();

        }

        // --------------- //


        // Preview Modal View //
        public ActionResult PreviewModal(int? id)
        {
            invoice invoice = db.invoices.Find(id);
            return View(invoice);
        }

        // Database Connection Disposal //
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        ////////////////////////////////////PRACTICE///////
        // GET: AndersonPayy/Edit/5        
        public ActionResult EditInvoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoice invoice = db.invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = id;
            ViewBag.CompanyName = new SelectList(db.companies, "CompanyName", "CompanyName", invoice.CompanyName);
            ViewBag.TypeOfService = new SelectList(db.typeofservices, "typeofserviceId", "NameOfService", invoice.TypeOfService);
            return View(invoice);
        }

        // POST: AndersonPayy/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInvoice([Bind(Include = "invoiceId,Date,DueDate,Quantity,Rate,Amount,Total,TypeOfService,CompanyName,Recipients,GovernmentTax,gtholder,WithholdingTax,ExpiringPeriod,whtholder,Signature,LateFee,lfholder,Address,Comments,Currency,StartPeriod,totalTax,invIdholder,Status,Deleted")] invoice invoice, string Submit, string Comments)
        {
            //DateTime date = DateTime.Today;
            //var seconddayofthemonth = new DateTime(date.Year, date.Month, 2);
            //var limited = invoice.ExpiringPeriod.AddMonths(1);

            //Converts everything from string to their definite var type
            var rateHldr = Convert.ToDecimal(invoice.Rate);
            var qtyHldr = Convert.ToInt32(invoice.Quantity);
            var lfHldr = Convert.ToDecimal(invoice.LateFee);

            //amount
            invoice.Amount = rateHldr * qtyHldr;
            //government tax


            //withholding tax
            //JEV WAS HERE NYAHAHA
            if (invoice.GovernmentTax == 12)
            {
                decimal x = invoice.Amount * invoice.GovernmentTax;
                invoice.gtholder = 12;
                decimal govtax = x / 100;
                invoice.GovernmentTax = govtax;
                invoice.WithholdingTax = 0;
                decimal y = invoice.Amount * invoice.WithholdingTax;
                invoice.whtholder = invoice.WithholdingTax;
                decimal whtax = y / 100;
                invoice.WithholdingTax = whtax;
            }

            if (invoice.WithholdingTax == 1)
            {

                invoice.WithholdingTax = 1;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = wttax;
                Convert.ToDouble(invoice.Amount);
                decimal y = invoice.Amount * wttax;
                invoice.WithholdingTax = y;


            }
            else if (invoice.WithholdingTax == 2)
            {


                invoice.WithholdingTax = 2;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = invoice.WithholdingTax;
                decimal y = invoice.Amount * wttax;
                invoice.WithholdingTax = y;



            }
            else if (invoice.WithholdingTax == 5)
            {


                invoice.WithholdingTax = 5;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = wttax;
                Convert.ToDouble(invoice.Amount);
                decimal y = invoice.Amount * wttax;
                invoice.WithholdingTax = y;



            }
            else
            {

                invoice.WithholdingTax = 0;
                decimal wttax = invoice.WithholdingTax / 100;
                invoice.whtholder = wttax;
                Convert.ToDouble(invoice.Amount);
                decimal y = invoice.Amount * wttax;
                invoice.WithholdingTax = y;

            }


            //latefee
            decimal q = invoice.Amount * lfHldr;
            invoice.lfholder = lfHldr;
            decimal latefee = q / 100;
            lfHldr = latefee;
            invoice.LateFee = Convert.ToString(lfHldr);


            invoice.Comments = Comments;
            invoice.totalTax = invoice.gtholder + invoice.whtholder + invoice.lfholder;
            invoice.Total = invoice.Amount + invoice.GovernmentTax + invoice.WithholdingTax + latefee;

            //if (date == seconddayofthemonth)
            //{
            //    invoice.Status = "Overdue";
            //}
            //if (invoice.ExpiringPeriod < DateTime.Today)
            //{
            //    invoice.Status = "Overdue";
            //}
            //else
            //{
            invoice.Status = "Pending";
            //}

            if (ModelState.IsValid)
            {
                switch (Submit)
                {
                    case "Preview":
                        return RedirectToAction("PreviewInvoice", invoice);

                    default:
                        db.Entry(invoice).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("EmailRedirect", new { id = invoice.invoiceId });
                }
            }
            ViewBag.CompanyName = new SelectList(db.companies, "CompanyName", "CompanyName", invoice.CompanyName);
            ViewBag.TypeOfService = new SelectList(db.typeofservices, "typeofserviceId", "NameOfService", invoice.TypeOfService);
            return View(invoice);
        }

        // GET: TypeOfServices/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: TypeOfServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "typeofserviceId,NameOfService")] typeofservice typeofservice)
        {
            if (ModelState.IsValid)
            {
                db.typeofservices.Add(typeofservice);
                db.SaveChanges();
                return RedirectToAction("CreateInvoice");
            }

            return RedirectToAction("CreateInvoice");
        }


        public ActionResult Home()
        {
            return View();
        }

        public ViewResult SearchArchive(int? page, string search)
        {
            int id = db.Archives.Max(a => a.SupportId);
            var results = from s in db.Archives where db.Archives.Contains(s) select s;

            if (!String.IsNullOrWhiteSpace(search))
            {
                var terms = search.Trim().Split(' ');
                results = results.Where(s => terms.Any(terms.Contains));
            }
            var MyViewModel = new ArchiveViewModel();
            MyViewModel.SupportId = id;


            return View(results.Where(x => x.Name.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 30));
        }

    }
}
