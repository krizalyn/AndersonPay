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
                AmountDue = invoice.AmountDue,
                Currency = invoice.Currency,
                Tax = invoice.Tax,
                //Comments = invoice.Comments,
                //Recipients = invoice.Recipients,
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
                AmountDue = eInvoice.AmountDue,
                TaxTypes = eInvoice.TaxTypes,
                Currency = eInvoice.Currency,
                Tax = eInvoice.Tax,
                //Recipients = eInvoice.Recipients,
                //Comments = eInvoice.Comments,
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
                AmountDue = a.AmountDue,
                Subtotal = a.Subtotal,
                TaxTypes = a.TaxTypes,
                Currency = a.Currency,
                Tax = a.Tax,
                //Recipients = a.Recipients,
                //Comments = a.Comments,
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
