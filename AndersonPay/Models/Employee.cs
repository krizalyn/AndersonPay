using AndersonPay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AndersonPay.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "Please Input Full Name")]
        public string FullName { get; set; }
        [Editable(true)]
        [DataType(DataType.Date)]
        public System.DateTime StartDate { get; set; }
        [Editable(true)]
        [DataType(DataType.Date)]
        public System.DateTime EndDate { get; set; }
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please Input Full Name")]
        public string JobName { get; set; }
        public virtual jobs jobs { get; set; }
        public virtual ICollection<MultipleService> MultipleServices { get; set; }
    }
}