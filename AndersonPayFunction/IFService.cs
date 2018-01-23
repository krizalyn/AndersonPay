using System.Collections.Generic;
using AndersonPayModel;
namespace AndersonPayFunction
{
    public interface IFService
    {
        #region CREATE
        Service Create(Service Service);
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
