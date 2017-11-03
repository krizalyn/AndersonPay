using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseData;
using AndersonPayContext;

namespace AndersonPayData
{
    public class DClient : DBase, IDClient {

        public DClient() : base(new Context()) {

        }
        #region CREATE
        #endregion
    }
}
