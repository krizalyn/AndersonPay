using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AndersonPayEntity
{
    [Table("Invoice")]
    public class EInvoice
    {
        /* 
         TO DO:
         Use identity as primary key
         Removed error messages
         Removed properties that are irelevant
         Use Capital Letters on non private properties
         Remove Display annotation
         Remove [HiddenInput(DisplayValue = true)] 
         Remove multipeServiceJSON
             */

        public bool? Deleted { get; set; }
        public bool Multiple { get; set; }

      //  [HiddenInput(DisplayValue = true)]
        public decimal Amount { get; set; }
       // [Display(Name = "Vatable Tax %")]
        public decimal GovernmentTax { get; set; }
        public decimal gtholder { get; set; }
        public decimal lfholder { get; set; }
       // [HiddenInput(DisplayValue = true)]
        public decimal Total { get; set; }
        public decimal totalTax { get; set; }
       // [Display(Name = "Withholding Tax %")]
        public decimal WithholdingTax { get; set; }
        public decimal whtholder { get; set; }

        public int? invIdholder { get; set; }
       // [Display(Name = "INV no.")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        [Editable(true)]
        //[Display(Name = "Date Create:")]
        //[DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Editable(true)]
        //[DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
        //[Required(ErrorMessage = "Please input the required Date")]
        //[DataType(DataType.Date)]
        public DateTime? ExpiringPeriod { get; set; }
        //[Required(ErrorMessage = "Please input the required Date")]
        //[DataType(DataType.Date)]
        public DateTime? StartPeriod { get; set; }

        public string Comments { get; set; }
        //[Display(Name = "Company Name")]
        //[Required(ErrorMessage = "Please Select Company")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please input the Currency type")]
        public string Currency { get; set; }
        public string Description { get; set; }
        //[Display(Name = "Late Fee %")]
        public string LateFee { get; set; }
        [NotMapped]
        public string multipeServiceJSON
        {
            get
            {
                return new JavaScriptSerializer().Serialize(Services);
            }
        }
        public string Quantity { get; set; }
        public string Rate { get; set; }
        public string Recipients { get; set; }
        public string Status { get; set; }
        //[Display(Name = "Type Of Service")]
        //Required(ErrorMessage = "Select Type of Service")]
        public string TypeOfService { get; set; }

        public string CompanyBranch { get; set; }
        //Address
        public string Address { get; set; }
        public string SingleSelected { get; set; }
        public string DropDownItems { get; set; }
        //name of Service
        public string NameOfService { get; set; }
        public decimal Subtotal { get; set; }


        public EClient Client { get; set; }

        public virtual ICollection<EService> Services { get; set; }
    }
}
