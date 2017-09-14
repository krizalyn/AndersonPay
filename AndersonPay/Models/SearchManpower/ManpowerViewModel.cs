using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndersonPay.Models.SearchManpower
{
    public class ManpowerViewModel
    {
        public int ManpowerId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        public virtual ICollection<ManpowerFile> ManpowerFiles { get; set; }
    }
}