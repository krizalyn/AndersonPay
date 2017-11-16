using AndersonPayContext;
using BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonPayData
{
    public class DInvoice : DBase, IDInvoice
    {
        public DInvoice() : base(new Context()) {

        }
    }
}
