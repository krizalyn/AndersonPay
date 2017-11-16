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
        public bool? Deleted { get; set; }
        public bool Multiple { get; set; }

        public decimal Amount { get; set; }

        public decimal GovernmentTax { get; set; }
        public decimal gtholder { get; set; }
        public decimal lfholder { get; set; }

        public decimal Total { get; set; }
        public decimal totalTax { get; set; }
        public decimal WithholdingTax { get; set; }
        public decimal whtholder { get; set; }

        public int? invIdholder { get; set; }
        public int invoiceId { get; set; }

        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ExpiringPeriod { get; set; }
        public DateTime StartPeriod { get; set; }

        public string Comments { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string LateFee { get; set; }

        public string multipeServiceJSON
        {
            get
            {
                return new JavaScriptSerializer().Serialize(multipleServices);
            }
        } 
        public string Quantity { get; set; }
        public string Rate { get; set; }
        public string Recipients { get; set; }
        public string Status { get; set; }

        public string TypeOfService { get; set; }

        public EClient Client { get; set; }

        public virtual ICollection<EMultipleService> multipleServices { get; set; }

    }
}
