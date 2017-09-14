using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPay.Models
{
    [Table("Invoice")]
    public class invoice
    {
        
        [Display(Name = "INV no.")]
        public int invoiceId { get; set; }

        [Editable(true)]
        [Display(Name = "Date Create:")]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }

        [Editable(true)]
        [DataType(DataType.Date)]
        public System.DateTime DueDate { get; set; }

        public string Description { get; set; }

        public string Quantity { get; set; }
        
        public string Rate { get; set; }

        [HiddenInput(DisplayValue = true)]
        public decimal Amount { get; set; }

        [HiddenInput(DisplayValue = true)]
        public decimal Total { get; set; }

        [Display(Name = "Type Of Service")]
        [Required(ErrorMessage = "Select Type of Service")]
        public string TypeOfService { get; set; }

      

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please Select Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Vatable Tax %")]
        public decimal GovernmentTax { get; set; }
        public decimal gtholder { get; set; }

        [Display(Name = "Withholding Tax %")]
        public decimal WithholdingTax { get; set; }
        public decimal whtholder { get; set; }

        [Display(Name = "Late Fee %")]
        public string LateFee { get; set; }
        public decimal lfholder { get; set; } 
        public string Comments { get; set; }

        [Required(ErrorMessage = "Please input the Currency type")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Please input the required Date")]
        [DataType(DataType.Date)]
        public System.DateTime StartPeriod { get; set; }

        [Required(ErrorMessage = "Please input the required Date")]
        [DataType(DataType.Date)]
        public System.DateTime ExpiringPeriod { get; set; }


        public decimal totalTax { get; set; }

        public Nullable<int> invIdholder { get; set; }
        public string Status { get; set; }
        public string Recipients { get; set; }

        public Nullable<bool> Deleted { get; set; }
        public bool Multiple { get; set; }

        public company Company { get; set; }
        
        public virtual ICollection<MultipleService> multipleServices { get; set; }
        

    }

}