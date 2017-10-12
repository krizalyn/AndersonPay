using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AndersonPay.Models
{
    [Table("TypeOfService")]
    public class typeofservice
    {

        public int typeofserviceId { get; set; }
        [Required(ErrorMessage = "Please Input the Service")]

        public decimal whTax { get; set; }
        public string NameOfService { get; set; }
        public bool IsSelected { get; set; }

        [Required(ErrorMessage = "Please input Rate")]
        public decimal Rate { get; set; }
        

        [Required(ErrorMessage = "Please input the Currency")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Please input a Service Description")]
        public string ServiceDescription { get; set; }

        //public virtual ICollection<MultipleService> MultipleServices { get; set; }


    }
}