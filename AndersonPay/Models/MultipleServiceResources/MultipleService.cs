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
        public string ServiceQuantity { get; set; }
        [Required(ErrorMessage = "Please Input the Rate")]
        public string ServiceRate { get; set; }
        public string SubTotal { get; set; }

  
        public virtual invoice invoice { get; set; }
        public virtual typeofservice typeofservices { get; set; }

       
    }
}