using System.Collections.Generic;
using AndersonPayModel;
using AndersonPayEntity;
namespace AndersonPayFunction
{
    public interface IFService
    {
        #region CREATE
        Service Create(int invoiceId, EService service);
        #endregion

        #region READ
        List<Service> Read(int id);
        #endregion

        #region Update
        Service Update(Service Service);
        #endregion

        #region DELETE
        void Delete(int invoiceId);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
