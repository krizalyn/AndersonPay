using AndersonPayFunction;
using System.Web.Mvc;
using AndersonPayModel;
namespace AndersonPay.Controllers
{
    public class TypeOfServiceController : Controller
    {
        // GET: TypeOfService

        private IFTypeOfService _iFTypeOfService;
        public TypeOfServiceController()
        {
            _iFTypeOfService = new FTypeOfService();
        }
        // Create new TypeOfService
        #region Create 
        [HttpGet]
        public ActionResult Create()
        {
            return View(new TypeOfService());
        }

        [HttpPost]
        public ActionResult Create(TypeOfService typeOfService)
        {
            typeOfService = _iFTypeOfService.Create(typeOfService);
            return RedirectToAction("Index");
            //, new { id = typeOfService.ClientId }
        }
        #endregion

        // Read list of TypeOfServices

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFTypeOfService.Read());
        }

        #endregion

        //UPDATE TYPEOFSERVICE
        #region Update
        [HttpGet]
        public ActionResult Update(int Id)
        {
            return View(_iFTypeOfService.Read(Id));
        }

        [HttpPost]
        public ActionResult Update(TypeOfService typeOfService)
        {
            typeOfService = _iFTypeOfService.Update(typeOfService);
            return RedirectToAction("Index");

        }
        #endregion

        //Delete TypeOfService
        #region Delete
        [HttpDelete]
        public JsonResult Delete(TypeOfService typeOfService)
        {

            _iFTypeOfService.Delete(typeOfService);
            return Json(string.Empty);

        }
        #endregion
    }
}