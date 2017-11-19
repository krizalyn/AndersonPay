using AndersonPayData;
using AndersonPayModel;
using AndersonPayEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonPayFunction
{
    public class FInvoice : IFInvoice
    {

        private IDInvoice _iDInvoice;

        public FInvoice(IDInvoice iDInvoice)
        {
            _iDInvoice = iDInvoice;
        }

        public FInvoice()
        {
            _iDInvoice = new DInvoice();
        }

        #region CREATE
        public Invoice Create(Invoice invoice)
        {
            EInvoice eInvoice = EInvoice(invoice);
            eInvoice = _iDInvoice.Create(eInvoice);
            return Invoice(eInvoice);
        }
        #endregion

        #region READ
        public Invoice Read(int invoiceId)
        {
            EInvoice eInvoice = _iDInvoice.Read<EInvoice>(a => a.invoiceId == invoiceId);
            return Invoice(eInvoice);
        }

        public List<Invoice> Read()
        {
            List<EInvoice> eInvoice = _iDInvoice.List<EInvoice>(a => true);
            return Invoice(eInvoice);
        }
        #endregion

        #region UPDATE
        public Invoice Update(Invoice invoice)
        {
            var eInvoice = _iDInvoice.Update(EInvoice(invoice));
            return (Invoice(eInvoice));
        }
        #endregion

        #region DELETE
        public void Delete(Invoice invoice)
        {
            _iDInvoice.Delete(EInvoice(invoice));
        }
        #endregion

        #region OTHER FUNCTION
        private EInvoice EInvoice(Invoice invoice)
        {
            EInvoice returnEInvoice = new EInvoice
            {
                Amount = invoice.Amount,
                GovernmentTax = invoice.GovernmentTax,
                gtholder = invoice.gtholder,
                lfholder = invoice.lfholder,
                Total = invoice.Total,
                totalTax = invoice.totalTax,
                WithholdingTax = invoice.WithholdingTax,
                whtholder = invoice.whtholder,
                invIdholder = invoice.invIdholder,
                invoiceId = invoice.invoiceId,
                Date = invoice.Date,
                DueDate = invoice.DueDate,
                ExpiringPeriod = invoice.ExpiringPeriod,
                StartPeriod = invoice.StartPeriod,
                Comments = invoice.Comments,
                Name = invoice.Name,
                Currency = invoice.Currency,
                Description = invoice.Description,
                LateFee = invoice.LateFee,
                Quantity = invoice.Quantity,
                Rate = invoice.Rate,
                Recipients = invoice.Recipients,
                Status = invoice.Status,
                TypeOfService = invoice.TypeOfService,
                multipleServices = invoice.multipleServices

            };
            return returnEInvoice;
        }

        private Invoice Invoice(EInvoice eInvoice)
        {
            Invoice returnInvoice = new Invoice
            {
                Amount = eInvoice.Amount,
                GovernmentTax = eInvoice.GovernmentTax,
                gtholder = eInvoice.gtholder,
                lfholder = eInvoice.lfholder,
                Total = eInvoice.Total,
                totalTax = eInvoice.totalTax,
                WithholdingTax = eInvoice.WithholdingTax,
                whtholder = eInvoice.whtholder,
                invIdholder = eInvoice.invIdholder,
                invoiceId = eInvoice.invoiceId,
                Date = eInvoice.Date,
                DueDate = eInvoice.DueDate,
                ExpiringPeriod = eInvoice.ExpiringPeriod,
                StartPeriod = eInvoice.StartPeriod,
                Comments = eInvoice.Comments,
                Name = eInvoice.Name,
                Currency = eInvoice.Currency,
                Description = eInvoice.Description,
                LateFee = eInvoice.LateFee,
                Quantity = eInvoice.Quantity,
                Rate = eInvoice.Rate,
                Recipients = eInvoice.Recipients,
                Status = eInvoice.Status,
                TypeOfService = eInvoice.TypeOfService,
                multipleServices = eInvoice.multipleServices
            };
            return returnInvoice;
        }

        private List<Invoice> Invoice(List<EInvoice> eInvoice)
        {
            var returnInvoice = eInvoice.Select(a => new Invoice
            {
                Amount = a.Amount,
                GovernmentTax = a.GovernmentTax,
                gtholder = a.gtholder,
                lfholder = a.lfholder,
                Total = a.Total,
                totalTax = a.totalTax,
                WithholdingTax = a.WithholdingTax,
                whtholder = a.whtholder,
                invIdholder = a.invIdholder,
                invoiceId = a.invoiceId,
                Date = a.Date,
                DueDate = a.DueDate,
                ExpiringPeriod = a.ExpiringPeriod,
                StartPeriod =a.StartPeriod,
                Comments = a.Comments,
                Name = a.Name,
                Currency = a.Currency,
                Description = a.Description,
                LateFee = a.LateFee,
                Quantity = a.Quantity,
                Rate = a.Rate,
                Recipients = a.Recipients,
                Status = a.Status,
                TypeOfService = a.TypeOfService,
                multipleServices = a.multipleServices

            });

            return returnInvoice.ToList();
        }


        #endregion
    }
}
