using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("MultipleService")]
    public class EMultipleService
    {
        /* 
         TO DO:
         Use identity as primary key
         Removed error messages
         Removed properties that are irelevant
         Use Capital Letters on non private properties
             */

        [Required(ErrorMessage = "Please Input the Quantity")]
        public decimal ServiceQuantity { get; set; }
        [Required(ErrorMessage = "Please Input the Rate")]
        public decimal ServiceRate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MultipleServiceId { get; set; }
        public int invoiceId { get; set; }

        [Required(ErrorMessage = "Please Input the Service")]
        public string NameOfService { get; set; }
        public string ServiceDescription { get; set; }

        public decimal SubTotal
        {
            get
            {
                return ServiceRate * ServiceQuantity;
            }
        }

        public virtual EInvoice invoice { get; set; }

        public virtual ETypeOfService typeofservices { get; set; }

    }
}
