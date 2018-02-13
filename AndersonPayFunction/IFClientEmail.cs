using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndersonPayModel;
namespace AndersonPayFunction
{
    public interface IFClientEmail
    {
        #region CREATE
        ClientEmail Create(ClientEmail clientEmail);
        #endregion

        #region READ
        ClientEmail Read(int clientEmailId);
        List<ClientEmail> Read();
        #endregion

        #region Update
        ClientEmail Update(ClientEmail clientEmail);
        #endregion

        #region DELETE
        void Delete(ClientEmail ClientEmail);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
