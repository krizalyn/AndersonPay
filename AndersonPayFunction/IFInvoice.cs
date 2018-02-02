using AndersonPayEntity;
using AndersonPayModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonPayFunction
{
    public interface IFInvoice
    {
        #region CREATE
        Invoice Create(Invoice invoice);
        #endregion

        #region READ
        Invoice Read(int invoiceId);
        List<Invoice> Read();
        #endregion

        #region Update
        Invoice Update(Invoice invoice);
        #endregion

        #region DELETE
        void Delete(int InvoiceId);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
