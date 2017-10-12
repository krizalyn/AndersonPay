using AndersonPay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AndersonPay.Models
{
    [Table("Company")]
    public class company
    {
        [Key]
        [Required(ErrorMessage = "Please Input Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please Input Company Address")]
        public string Address { get; set; }
                
        [Required(ErrorMessage = "Please Input Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please Input the Tax Identification Number")]
        public int TIN { get; set; }

        
        [Display(Name = "Contact Person"), Required]
        public string ContactPerson { get; set; }

        [Display(Name = "Telephone Number"), Required]
        public int TelephoneNumber { get; set; }

        [Required(ErrorMessage = "Please Select Country Type")]
        [Display(Name = "Type Of Company")]

        
        public string FORDO { get; set; }

        [Display(Name = "Tax Type"), Required]
        public string Tax { get; set; }

        [Display(Name = "Withholding Tax %")]
        public int Wtpercent { get; set; }

        [Required(ErrorMessage = "Please Input Company Code")]
        public string CompanyCode { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Contact Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter your Recipients")]
        public string Recipients { get; set; }

        public string FullName { get; set; }
        public Employee Employee { get; set; }
    }
}