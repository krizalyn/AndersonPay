using BaseModel;
using System.Collections.Generic;

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
