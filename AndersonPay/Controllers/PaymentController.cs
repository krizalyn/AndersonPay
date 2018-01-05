using AndersonPayFunction;
using System.Web.Mvc;
using AndersonPayModel;
namespace AndersonPay.Controllers
{
    public class ReceivePaymentController : Controller
    {
        // GET: Payment

        private IFReceivePayment _iFReceivePayment;
        public ReceivePaymentController()
        {
            _iFReceivePayment = new FReceivePayment();
        }

        // Create new Payment
        #region Create 
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ReceivePayment());
        }

        [HttpPost]
        public ActionResult Create(ReceivePayment payment)
        {
            payment = _iFReceivePayment.Create(payment);
            return RedirectToAction("Index", "ReceivePayment");
            //, new { id = payment.PaymentId }
        }
        #endregion

        // Read list of clients

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFReceivePayment.Read());
        }

        #endregion

        //UPDATE CLIENT
        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFReceivePayment.Read(id));
        }

        [HttpPost]
        public ActionResult Update(ReceivePayment payment)
        {
            payment = _iFReceivePayment.Update(payment);
            return RedirectToAction("Index", "ReceivePayment");

        }
        #endregion

        //Delete Client
        #region Delete
        [HttpDelete]
        public JsonResult Delete(ReceivePayment payment)
        {

            _iFReceivePayment.Delete(payment);
            return Json(string.Empty);

        }
        #endregion

        
    }
}