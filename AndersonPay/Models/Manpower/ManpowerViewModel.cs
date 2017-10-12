using AndersonPayEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndersonPay.Models.Manpower
{
    public class ManpowerViewModel
    {
        public int ManpowerId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        public virtual ICollection<EManpowerFile> ManpowerFiles { get; set; }
    }
}