using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AndersonPay.Models
{
    public class MultipleService
    {
        public int MultipleServiceId { get; set; }

        public int invoiceId { get; set; }

        [Required(ErrorMessage = "Please Input the Service")]
        public string NameOfService { get; set; }

        [Required(ErrorMessage = "Please Input the Quantity")]
        public decimal ServiceQuantity { get; set; }

        [Required(ErrorMessage = "Please Input the Rate")]

        public string ServiceDescription { get; set; }

        public decimal ServiceRate { get; set; }

        public decimal SubTotal
        {
            get
            {
                return ServiceRate * ServiceQuantity;
            }
        }
       
        public virtual invoice invoice { get; set; }

        public virtual typeofservice typeofservices { get; set; }

       
    }
}