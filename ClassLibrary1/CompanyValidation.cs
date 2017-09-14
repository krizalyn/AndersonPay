using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1 
{
    public class CompanyValidation
    {
        [Required(ErrorMessage = "Please Input Company Name")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please Input Company Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Input Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Input the Tax Identification Number")]
        public int TIN { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name = "Telephone Number")]
        public int TelephoneNumber { get; set; }
        [Required(ErrorMessage = "Please Select Country Type")]
        [Display(Name = "Type Of Company")]
        public string FORDO { get; set; }
        [Display(Name = "Tax Type")]
        public string Tax { get; set; }
        [Required(ErrorMessage = "Please Input Company Code")]
        public string CompanyCode { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Contact Email")]
        [Required(ErrorMessage = "Please Enter your Recipients")]
        public string Recipients { get; set; }
        public string FullName { get; set; }
        public Employee Employee { get; set; }
    }
}
