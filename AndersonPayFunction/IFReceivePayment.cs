using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndersonPayModel;

namespace AndersonPayFunction
{
    public interface IFReceivePayment
    {
        #region CREATE
        ReceivePayment Create(ReceivePayment payment);
        #endregion

        #region READ
        ReceivePayment Read(int paymentId);
        List<ReceivePayment> Read();
        #endregion

        #region Update
        ReceivePayment Update(ReceivePayment payment);
        #endregion

        #region DELETE
        void Delete(ReceivePayment Payment);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
