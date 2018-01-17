using AndersonPayFunction;
using System.Web.Mvc;
using AndersonPayModel;
namespace AndersonPay.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment

        private IFPayment _iFPayment;
        public PaymentController()
        {
            _iFPayment = new FPayment();
        }
        // Create new Payment
        #region Create 
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Payment());
        }

        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            payment = _iFPayment.Create(payment);
            return RedirectToAction("Index");
            //, new { id = payment.PaymentId }
        }
        #endregion

        // Read list of Payment

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFPayment.Read());
        }

        #endregion

        //UPDATE TYPEOFSERVICE
        #region Update
        [HttpGet]
        public ActionResult Update(int Id)
        {
            return View(_iFPayment.Read(Id));
        }

        [HttpPost]
        public ActionResult Update(Payment payment)
        {
            payment = _iFPayment.Update(payment);
            return RedirectToAction("Index");

        }
        #endregion

        //Delete TypeOfService
        #region Delete
        [HttpDelete]
        public JsonResult Delete(Payment payment)
        {

            _iFPayment.Delete(payment);
            return Json(string.Empty);

        }
        #endregion
    }
}