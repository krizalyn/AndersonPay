using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AndersonPay.Models.Manpower
{
    public class ManpowerResults
    {
        public string Name { get; set; }
        [MaxLength(500)]
        public string Detail { get; set; }
        public List<ManpowerViewModel> Employees { get; set; }
    }
}