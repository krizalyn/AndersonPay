using AndersonPayFunction;
using System.Web.Mvc;
using AndersonPayModel;
namespace AndersonPay.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client

        private IFClient _iFClient;
        public ClientController()
        {
            _iFClient = new FClient();
        }
        // Create new Client
        #region Create 
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Client());
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            client = _iFClient.Create(client);
            return RedirectToAction("Index", new { id = client.ClientId });
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
            return Json(_iFClient.Read());
        }

        #endregion

        //UPDATE CLIENT
        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFClient.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Client client)
        {
            client = _iFClient.Update(client);
            return RedirectToAction("Index");

        }
        #endregion

        //Delete Client
        #region Delete
        [HttpDelete]
        public JsonResult Delete(Client client)
        {

            _iFClient.Delete(client);
            return Json(string.Empty);

        }
        #endregion
    }
}