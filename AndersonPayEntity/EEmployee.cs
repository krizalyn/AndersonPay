using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("Employee")]
    public class EEmployee
    {
        /* 
         TO DO:
         Separate Full Name into First, Middle and Last
         Use identity as primary key
         Removed error messages
         Removed properties that are irelevant
         Use Capital Letters on non private properties
             */

        [Editable(true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Editable(true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public string CompanyName { get; set; }
        [Key]
        [Required(ErrorMessage = "Please Input Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please Input Full Name")]
        public string JobName { get; set; }
        public virtual EJobs jobs { get; set; }
    }
}
