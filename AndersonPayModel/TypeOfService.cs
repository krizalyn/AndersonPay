using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseModel;

namespace AndersonPayModel
{
    public class TypeOfService : Base
    {
        public int TypeOfServiceId { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }

        public List<Service> Services { get; set; }
    }
}
