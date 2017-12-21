using AndersonPayEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AndersonPayModel
{
    public class Invoice : Base.Base
    {
        
        //public bool? Deleted { get; set; }                  /*tobe deleted*/
        //public bool Multiple { get; set; }                  /*tobe deleted*/

        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal WithholdingTax { get; set; }
        
        public int InvoiceId { get; set; }

        //public DateTime? Date { get; set; }                 /*tobe deleted*/
        //public DateTime? DueDate { get; set; }              /*tobe deleted*/
        //public DateTime? ExpiringPeriod { get; set; }       /*tobe deleted*/
        //public DateTime? StartPeriod { get; set; }          /*tobe deleted*/

        public string Comments { get; set; }
        public string Name { get; set; }                    /*tobe deleted*/
        public string Currency { get; set; }
        public string Description { get; set; }             /*tobe deleted*/
        public string LateFee { get; set; }                 /*tobe deleted*/

        public string Quantity { get; set; }
        public string Rate { get; set; }                    /*tobe deleted*/
        public string Recipients { get; set; }
        public string Status { get; set; }

        public string TypeOfService { get; set; }           /*tobe deleted*/

        public EClient Client { get; set; }

        public virtual List<EService> Services { get; set; }
        public string SINo { get; set; }
        public string TIN { get; set; }
    }
}
