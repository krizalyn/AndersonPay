using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("Company")]
    public class ECompany
    {
        /* 
         TO DO:
         Separate Full Name into First, Middle and Last
         Use identity as primary key
         Removed error messages
         Removed properties that are irelevant properties
         Use Capital Letters on non private properties
             */
        [Display(Name = "Telephone Number"), Required]
        public int TelephoneNumber { get; set; }
        [Required(ErrorMessage = "Please Input the Tax Identification Number")]
        public int TIN { get; set; }
        [Display(Name = "Withholding Tax %")]
        public int Wtpercent { get; set; }

        [Required(ErrorMessage = "Please Input Company Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Input Company Code")]
        public string CompanyCode { get; set; }
        [Key]
        [Required(ErrorMessage = "Please Input Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Contact Person"), Required]
        public string ContactPerson { get; set; }
        [Required(ErrorMessage = "Please Input Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Select Country Type")]
        [Display(Name = "Type Of Company")]
        public string FORDO { get; set; }
        [Display(Name = "Currency")]
        public string Currency { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Contact Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter your Recipients")]
        public string Recipients { get; set; }
        [Display(Name = "Tax Type"), Required]
        public string Tax { get; set; }
        public EEmployee Employee { get; set; }
    }
}
