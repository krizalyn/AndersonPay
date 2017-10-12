using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AndersonPay.Models.Manpower
{
    [Table("ManpowerFile")]
    public class ManpowerFile
    {

        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string Annex { get; set; }
        public int ManpowerId { get; set; }
        public virtual Manpower Verify { get; set; }


    }
}