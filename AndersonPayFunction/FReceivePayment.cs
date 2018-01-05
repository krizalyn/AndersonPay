using System;
using System.Collections.Generic;
using System.Linq;
using AndersonPayData;
using AndersonPayModel;
using AndersonPayEntity;

namespace AndersonPayFunction   
{
  public class FReceivePayment : IFReceivePayment
    {
        private IDReceivePayment _iDReceivePayment;

        public FReceivePayment(IDReceivePayment iDReceivePayment)
        {
            _iDReceivePayment = iDReceivePayment;
        }

        public FReceivePayment()
        {
            _iDReceivePayment = new DReceivePayment();
        }

        #region CREATE
        public ReceivePayment Create(ReceivePayment payment)
        {
            EReceivePayment eReceivePayment = EReceivePayment(payment);
            eReceivePayment = _iDReceivePayment.Create(eReceivePayment);
            return ReceivePayment(eReceivePayment);
        }
        #endregion

        #region READ
        public ReceivePayment Read(int paymentId)
        {
            EReceivePayment eReceivePayment = _iDReceivePayment.Read<EReceivePayment>(a => a.PaymentId == paymentId);
            return ReceivePayment(eReceivePayment);
        }

        public List<ReceivePayment> Read()
        {
            List<EReceivePayment> eReceivePayment = _iDReceivePayment.List<EReceivePayment>(a => true);
            return ReceivePayment(eReceivePayment);
        }
        #endregion

        #region UPDATE
        public ReceivePayment Update(ReceivePayment payment)
        {
            var eReceivePayment = _iDReceivePayment.Update(EReceivePayment(payment));
            return (ReceivePayment(eReceivePayment));
        }
        #endregion

        #region DELETE
        public void Delete(ReceivePayment payment)
        {
            _iDReceivePayment.Delete(EReceivePayment(payment));
        }
        #endregion

        #region OTHER FUNCTION
        private EReceivePayment EReceivePayment(ReceivePayment payment)
        {
            EReceivePayment returnEPayment = new EReceivePayment
            {
                AmountOfPayment = payment.AmountOfPayment,
                DateOfPayment = payment.DateOfPayment,
                PaymentId = payment.PaymentId
            };
            return returnEPayment;
        }

        private ReceivePayment ReceivePayment(EReceivePayment eReceivePayment)
        {
            ReceivePayment returnPayment = new ReceivePayment
            {
                AmountOfPayment = eReceivePayment.AmountOfPayment,
                DateOfPayment = eReceivePayment.DateOfPayment,
                PaymentId = eReceivePayment.PaymentId
            };
            return returnPayment;
        }

        private List<ReceivePayment> ReceivePayment (List<EReceivePayment> eReceivePayment)
        {
            var returnPayment = eReceivePayment.Select(a => new ReceivePayment
            {
                AmountOfPayment = a.AmountOfPayment,
                DateOfPayment = a.DateOfPayment,
                PaymentId = a.PaymentId
            });

            return returnPayment.ToList();
        }

        #endregion
    }
}
