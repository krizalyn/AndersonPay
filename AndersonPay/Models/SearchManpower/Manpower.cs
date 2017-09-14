using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AndersonPay.Models.SearchManpower
{
    [Table("Manpower")]
    public class Manpower
    {
        [Key]
        public int ManpowerId { get; set; }

        [Required(ErrorMessage = "Please enter the filename")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Detail")]
        [MaxLength(500)]
        public string Detail { get; set; }


        public virtual ICollection<ManpowerFile> ManpowerFiles { get; set; }
    }
}