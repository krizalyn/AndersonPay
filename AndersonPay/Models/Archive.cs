using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AndersonPay.Models
{
    [Table("Archive")]
    public class Archive
    {
        [Key]
        public int SupportId { get; set; }

        [Required(ErrorMessage = "Please enter the Archive name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Summary")]
        [MaxLength(500)]
        public string Summary { get; set; }


        public virtual ICollection<FileDetail> FileDetails { get; set; }
    }
}