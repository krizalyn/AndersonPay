using AndersonPayContext;
using BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonPayData
{
    public class DPayment : DBase, IDPayment
    {

        public DPayment() : base(new Context())
        {

        }
       
    }
}
