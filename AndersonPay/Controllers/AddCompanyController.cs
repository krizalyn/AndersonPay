using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AndersonPayContext;
using AndersonPayEntity;

namespace AndersonPay.Controllers
{
    public class AddCompanyController : Controller
    {
        private Context db = new Context();

        // GET: AddCompany
        public ActionResult Index()
        {
            return View(db.companies.ToList());
        }

        // GET: AddCompany/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECompany company = db.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }
        // GET: AddCompany/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: AddCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyName,Address,Country,TIN,Recipients,ContactPerson,TelephoneNumber,FORDO,Currency,Tax,CompanyCode,Wtpercent")] ECompany company)
        {
            if (ModelState.IsValid)
            {
                db.companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: AddCompany/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECompany company = db.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return PartialView(company);
        }

        // POST: AddCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyName,Address,Country,TIN,Recipients,ContactPerson,TelephoneNumber,FORDO,Currency,Tax,CompanyCode,Email,Wtpercent")] ECompany company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: AddCompany/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECompany company = db.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return PartialView(company);
        }

        // POST: AddCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ECompany company = db.companies.Find(id);
            db.companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
