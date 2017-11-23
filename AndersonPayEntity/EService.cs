using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonPayEntity
{
    public class EService
    {

        public decimal ServiceQuantity { get; set; }
        public decimal ServiceRate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MultipleServiceId { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }

        public string NameOfService { get; set; }
        public string ServiceDescription { get; set; }

        public decimal SubTotal
        {
            get
            {
                return ServiceRate * ServiceQuantity;
            }
        }

        public virtual EInvoice Invoice { get; set; }

        public virtual ETypeOfService typeofservices { get; set; }
    }
}
