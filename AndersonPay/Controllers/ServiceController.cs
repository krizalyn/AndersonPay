using AndersonPayFunction;
using System.Web.Mvc;
using AndersonPayModel;
namespace AndersonPay.Controllers
{
    public class ServiceController : Controller
    {


        private IFService _iFService;
        public ServiceController()
        {
            _iFService = new FService();
        }
        // Create new Service
        #region Create
        #endregion

        // Read list of Services

        #region Read
        [HttpPost]
        public JsonResult Read(int id)
        {
            return Json(_iFService.Read(id));
        }
        #endregion

        //UPDATE SERVICE
        #region Update
        #endregion

        //Delete Service
        #region Delete
        #endregion
    }
}