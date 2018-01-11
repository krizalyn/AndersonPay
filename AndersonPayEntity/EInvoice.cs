using BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AndersonPayEntity
{
    [Table("Invoice")]
    public class EInvoice : EBase
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

        //public bool? Deleted { get; set; } //Remove
        //public bool Multiple { get; set; } //Remove
        //public decimal totalTax { get; set; } //Remove
        //// [Display(Name = "Withholding Tax %")]

        //public decimal whtholder { get; set; } //Remove

        //public int? invIdholder { get; set; } //Remove
        //public DateTime? Date { get; set; } //Remove
        //[Editable(true)] //Remove
        ////[Display(Name = "Date Create:")]
        ////[DataType(DataType.Date)]
        ////[DataType(DataType.Date)]
        //public DateTime? DueDate { get; set; } //Remove
        ////[Required(ErrorMessage = "Please input the required Date")]
        ////[DataType(DataType.Date)]
        //public DateTime? ExpiringPeriod { get; set; } //Remove
        ////[Required(ErrorMessage = "Please input the required Date")]
        ////[DataType(DataType.Date)]
        //public DateTime? StartPeriod { get; set; } //Remove
        //public string Name { get; set; } //Remove
        ////[Required(ErrorMessage = "Please input the Currency type")]
        //public string Description { get; set; } //Remove
        ////[Display(Name = "Late Fee %")]
        //public string LateFee { get; set; } //Remove
        //[NotMapped]
        //public string multipeServiceJSON //Remove
        //{
        //    get
        //    {
        //        return new JavaScriptSerializer().Serialize(Services);
        //    }
        //}
        //public string Quantity { get; set; } //Remove
        //public string Rate { get; set; } //Remove
        //public string Recipients { get; set; }
        //public string Status { get; set; } //Remove
        ////[Display(Name = "Type Of Service")]
        ////Required(ErrorMessage = "Select Type of Service")]
        //public string TypeOfService { get; set; } //Remove
        //  [HiddenInput(DisplayValue = true)]
        //public string Comments { get; set; }
        //[Display(Name = "Company Name")]
        //[Required(ErrorMessage = "Please Select Company")]
        // [Display(Name = "INV no.")]

        public decimal AmountDue { get; set; }
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        public decimal Tax { get; set; }
        public string Currency { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public EClient Client { get; set; }
        public virtual ICollection<EService> Services { get; set; }
        //public string CompanyBranch { get; set; }

        public string Name { get; set; }
        //public string Recipients { get; set; }
        public string TaxTypes { get; set; }
        //public string NameOfService { get; set; }
        //public decimal Subtotal { get; set; }
        public string SINo { get; set; }
        public string TIN { get; set; }
        public string Address { get; set; }
        
        //public DateTime DueDate { get; set; }
        public int NumberOfDelays { get; set; }
        public decimal Interest { get; set; }
    }
}
