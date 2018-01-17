using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndersonPayModel;
namespace AndersonPayFunction
{
    public interface IFPayment
    {
        #region CREATE
        Payment Create(Payment payment);
        #endregion

        #region READ
        Payment Read(int paymentId);
        List<Payment> Read();
        #endregion

        #region Update
        Payment Update(Payment payment);
        #endregion

        #region DELETE
        void Delete(Payment Payment);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
