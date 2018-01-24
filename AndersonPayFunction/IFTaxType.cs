using System.Collections.Generic;
using AndersonPayModel;

namespace AndersonPayFunction
{
    public interface IFTaxType
    {
        #region CREATE
        TaxType Create(TaxType taxType);
        #endregion

        #region READ
        TaxType Read(int taxTypeId);
        List<TaxType> Read();
        #endregion

        #region Update
        TaxType Update(TaxType taxType);
        #endregion

        #region DELETE
        void Delete(int taxTypeId);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
