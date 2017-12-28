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
            EInvoice eInvoice = _iDInvoice.Read<EInvoice>(a => a.InvoiceId == invoiceId);
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

                //GovernmentTax = invoice.GovernmentTax,
                //gtholder = invoice.gtholder,
                //lfholder = invoice.lfholder,
                //totalTax = invoice.totalTax,
                //whtholder = invoice.whtholder,
                //invIdholder = invoice.invIdholder,
                //Date = invoice.Date,
                //DueDate = invoice.DueDate,
                //ExpiringPeriod = invoice.ExpiringPeriod,
                //StartPeriod = invoice.StartPeriod,
                //Description = invoice.Description,
                //LateFee = invoice.LateFee,
                //Quantity = invoice.Quantity,
                //Rate = invoice.Rate,
                //Status = invoice.Status,
                //TypeOfService = invoice.TypeOfService,

                InvoiceId = invoice.InvoiceId,
                Name = invoice.Name,
                TaxTypes = invoice.TaxTypes,
                Subtotal = invoice.Subtotal,
                Total = invoice.Total,
                Currency = invoice.Currency,
                Comments = invoice.Comments,
                Recipients = invoice.Recipients,
                Services = invoice.Services,
                SINo = invoice.SINo,
                TIN = invoice.TIN
            };
            return returnEInvoice;
        }

        private Invoice Invoice(EInvoice eInvoice)
        {
            Invoice returnInvoice = new Invoice
            {

                //GovernmentTax = eInvoice.GovernmentTax,
                //gtholder = eInvoice.gtholder,
                //lfholder = eInvoice.lfholder,
                //totalTax = eInvoice.totalTax,
                //whtholder = eInvoice.whtholder,
                //invIdholder = eInvoice.invIdholder,
                //Date = eInvoice.Date,
                //DueDate = eInvoice.DueDate,
                //ExpiringPeriod = eInvoice.ExpiringPeriod,
                //StartPeriod = eInvoice.StartPeriod,
                //Name = eInvoice.Name,
                //Description = eInvoice.Description,
                //LateFee = eInvoice.LateFee,
                //Quantity = eInvoice.Quantity,
                //Rate = eInvoice.Rate,
                //Status = eInvoice.Status,
                //TypeOfService = eInvoice.TypeOfService,

                InvoiceId = eInvoice.InvoiceId,
                Name = eInvoice.Name,
                Subtotal = eInvoice.Subtotal,
                Total = eInvoice.Total,
                TaxTypes = eInvoice.TaxTypes,
                Currency = eInvoice.Currency,
                Recipients = eInvoice.Recipients,
                Comments = eInvoice.Comments,
                SINo = eInvoice.SINo,
                TIN = eInvoice.TIN
            };

            return returnInvoice;
        }

        private List<Invoice> Invoice(List<EInvoice> eInvoice)
        {
            var returnInvoice = eInvoice.Select(a => new Invoice
            {

                //GovernmentTax = a.GovernmentTax,
                //gtholder = a.gtholder,
                //lfholder = a.lfholder,
                //totalTax = a.totalTax,
                //whtholder = a.whtholder,
                //invIdholder = a.invIdholder,
                //Date = a.Date,
                //DueDate = a.DueDate,
                //ExpiringPeriod = a.ExpiringPeriod,
                //StartPeriod = a.StartPeriod,
                //Name = a.Name,
                //Description = a.Description,
                //LateFee = a.LateFee,
                //Quantity = a.Quantity,
                //Rate = a.Rate,
                //Status = a.Status,
                //TypeOfService = a.TypeOfService,

                InvoiceId = a.InvoiceId,
                Name = a.Name,
                Total = a.Total,
                Subtotal = a.Subtotal,
                TaxTypes = a.TaxTypes,
                Currency = a.Currency,
                Recipients = a.Recipients,
                Comments = a.Comments,
                SINo = a.SINo,
                TIN = a.TIN

            });

            return returnInvoice.ToList();
        }

        #endregion
    }
}
