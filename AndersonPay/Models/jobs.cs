
using AndersonPay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AndersonPay.Models
{
    [Table("Jobs")]
    public class jobs
    {
       [Key]
        [Required(ErrorMessage = "Please Input Job Position")]
        public string JobName { get; set; }
        [Required(ErrorMessage = "Please Input Currency")]
        public string Currency { get; set; }
        [Required(ErrorMessage = "Please Select Type of Pay")]
        public string RateType { get; set; }
        [Required(ErrorMessage = "Please Input Rate")]
        public decimal Rate { get; set; }

    }
}