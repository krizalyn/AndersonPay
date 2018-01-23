using AndersonPayData;
using AndersonPayEntity;
using AndersonPayModel;
using System.Collections.Generic;
using System.Linq;

namespace AndersonPayFunction
{
    public class FService : IFService
    {
        private IDService _iDService;

        public FService(IDService iDService)
        {
            _iDService = iDService;
        }

        public FService()
        {
            _iDService = new DService();
        }

        #region CREATE
        public Service Create(int invoiceId, EService service)
        {
            EService eService = service;
            eService.InvoiceId = invoiceId;
            eService = _iDService.Create(eService);
            return Service(eService);
        }
        #endregion

        #region READ
        public List<Service> Read(int id)
        {
            List<EService> eService = _iDService.List<EService>(a => a.InvoiceId == id);
            return Service(eService);
        }
        #endregion

        #region UPDATE
        public Service Update(Service service)
        {
            var eService = _iDService.Update(EService(service));
            return (Service(eService));
        }
        #endregion

        #region DELETE
        public void Delete(int invoiceId)
        {
            _iDService.Delete<EService>(a => a.InvoiceId == invoiceId);
            //_iDService.Delete(EService(service));
        }
        #endregion

        #region OTHER FUNCTION
        private EService EService(Service service)
        {
            EService returnEService = new EService
            {
                ServiceId = service.ServiceId,
                Description = service.Description,
                Quantity = service.Quantity,
                Rate = service.Rate,
                InvoiceId = service.InvoiceId,
                TypeOfServiceId = service.TypeOfServiceId,
                Comments = service.Comments
            };

            return returnEService;
        }

        private Service Service(EService eService)
        {
            Service returnService = new Service
            {
                ServiceId = eService.ServiceId,
                Description = eService.Description,
                Quantity = eService.Quantity,
                Rate = eService.Rate,
                InvoiceId = eService.InvoiceId,
                TypeOfServiceId = eService.TypeOfServiceId,
                Comments = eService.Comments
            };
            return returnService;
        }

        private List<Service> Service(List<EService> eService)
        {
            var returnService = eService.Select(a => new Service
            {
                ServiceId = a.ServiceId,
                Description = a.Description,
                Quantity = a.Quantity,
                Rate = a.Rate,
                InvoiceId = a.InvoiceId,
                TypeOfServiceId = a.TypeOfServiceId,
                Comments = a.Comments
            });

            return returnService.ToList();
        }


        #endregion
    }
}
