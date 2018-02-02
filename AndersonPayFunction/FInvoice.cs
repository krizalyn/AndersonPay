using AndersonPayData;
using AndersonPayModel;
using AndersonPayEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

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
            eInvoice.CreatedDate = DateTime.Now;
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
            //_iDInvoice.Delete<EService>(a => a.InvoiceId == invoice.InvoiceId);
            var eInvoice = EInvoice(invoice);
            eInvoice.Services = null;
            eInvoice = _iDInvoice.Update(eInvoice);
            return (Invoice(eInvoice));
        }
        #endregion

        #region DELETE
        public void Delete(int invoiceId)
        {
            //_iDInvoice.Delete(EInvoice(invoice));
            _iDInvoice.Delete<EService>(a => a.InvoiceId == invoiceId);
            _iDInvoice.Delete<EInvoice>(a => a.InvoiceId == invoiceId);
        }
        #endregion

        #region OTHER FUNCTION
        private EInvoice EInvoice(Invoice invoice)
        {
            EInvoice returnEInvoice = new EInvoice
            {

                InvoiceId = invoice.InvoiceId,
                Name = invoice.Name,
                TaxTypes = invoice.TaxTypes,
                Subtotal = invoice.Subtotal,
                AmountDue = invoice.AmountDue,
                Currency = invoice.Currency,
                Tax = invoice.Tax,
                Services = invoice.Services?.Select(a => new EService
                {
                    Quantity = a.Quantity,
                    Rate = a.Rate,
                    Subtotal = a.Subtotal,

                    InvoiceId = a.InvoiceId,
                    ServiceId = a.ServiceId,
                    TypeOfServiceId = a.TypeOfServiceId,

                    Description = a.Description,
                    Comments = a.Comments
                }).ToList() ?? null,
                SINo = invoice.SINo,
                TIN = invoice.TIN,
                Address = invoice.Address,
                ClientId = invoice.ClientId,
                CreatedDate = invoice.CreatedDate,
                DueDate = invoice.DueDate
            };
            return returnEInvoice;
        }

        private Invoice Invoice(EInvoice eInvoice)
        {
            Invoice returnInvoice = new Invoice
            {
                InvoiceId = eInvoice.InvoiceId,
                Name = eInvoice.Name,
                Subtotal = eInvoice.Subtotal,
                AmountDue = eInvoice.AmountDue,
                TaxTypes = eInvoice.TaxTypes,
                Currency = eInvoice.Currency,
                Tax = eInvoice.Tax,
                SINo = eInvoice.SINo,
                TIN = eInvoice.TIN,
                Address = eInvoice.Address,
                ClientId = eInvoice.ClientId,
                CreatedDate = eInvoice.CreatedDate
            };

            return returnInvoice;
        }

        private List<Invoice> Invoice(List<EInvoice> eInvoice)
        {
            var returnInvoice = eInvoice.Select(a => new Invoice
            {

                InvoiceId = a.InvoiceId,
                Name = a.Name,
                AmountDue = a.AmountDue,
                Subtotal = a.Subtotal,
                TaxTypes = a.TaxTypes,
                Currency = a.Currency,
                Tax = a.Tax,
                SINo = a.SINo,
                TIN = a.TIN,
                Address = a.Address,
                ClientId = a.ClientId,
                CreatedDate = a.CreatedDate

            });

            return returnInvoice.ToList();
        }

        #endregion
    }
}
