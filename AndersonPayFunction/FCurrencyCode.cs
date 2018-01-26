using System;
using System.Collections.Generic;
using System.Linq;
using AndersonPayData;
using AndersonPayModel;
using AndersonPayEntity;

namespace AndersonPayFunction   
{
  public class FCurrencyCode : IFCurrencyCode
    {
        private IDCurrencyCode _iDCurrencyCode;

        public FCurrencyCode(IDCurrencyCode iDCurrencyCode)
        {
            _iDCurrencyCode = iDCurrencyCode;
        }

        public FCurrencyCode()
        {
            _iDCurrencyCode = new DCurrencyCode();
        }

        #region CREATE
        public CurrencyCode Create(CurrencyCode currencyCode)
        {
            ECurrencyCode eCurrencyCode = ECurrencyCode(currencyCode);
            eCurrencyCode = _iDCurrencyCode.Create(eCurrencyCode);
            return CurrencyCode(eCurrencyCode);
        }
        #endregion

        #region READ
        public CurrencyCode Read(int currencyCodeId)
        {
            ECurrencyCode eCurrencyCode = _iDCurrencyCode.Read<ECurrencyCode>(a => a.CurrencyCodeId == currencyCodeId);
            return CurrencyCode(eCurrencyCode);
        }

        public List<CurrencyCode> Read()
        {
            List<ECurrencyCode> eCurrencyCode = _iDCurrencyCode.List<ECurrencyCode>(a => true);
            return CurrencyCode(eCurrencyCode);
        }
        #endregion

        #region UPDATE
        public CurrencyCode Update(CurrencyCode currencyCode)
        {
            var eCurrencyCode = _iDCurrencyCode.Update(ECurrencyCode(currencyCode));
            return (CurrencyCode(eCurrencyCode));
        }
        #endregion

        #region DELETE
        public void Delete(int currencyCodeId)
        {
            _iDCurrencyCode.Delete<ECurrencyCode>(a => a.CurrencyCodeId == currencyCodeId);
        }
        #endregion

        #region OTHER FUNCTION
        private ECurrencyCode ECurrencyCode(CurrencyCode currencyCode)
        {
            ECurrencyCode returnECurrencyCode = new ECurrencyCode
            {
                CurrencyCodeId = currencyCode.CurrencyCodeId,
                CurrencyCodes = currencyCode.CurrencyCodes
            };
            return returnECurrencyCode;
        }

        private CurrencyCode CurrencyCode(ECurrencyCode eCurrencyCode)
        {
            CurrencyCode returnCurrencyCode = new CurrencyCode
            {
                CurrencyCodeId = eCurrencyCode.CurrencyCodeId,
                CurrencyCodes = eCurrencyCode.CurrencyCodes
            };
            return returnCurrencyCode;
        }

        private List<CurrencyCode> CurrencyCode(List<ECurrencyCode> eCurrencyCode)
        {
            var returnCurrencyCode = eCurrencyCode.Select(a => new CurrencyCode
            {
                CurrencyCodeId = a.CurrencyCodeId,
                CurrencyCodes = a.CurrencyCodes

            });
            return returnCurrencyCode.ToList();
        }

        #endregion
    }
}
