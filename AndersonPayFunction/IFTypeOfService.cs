using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndersonPayModel;
namespace AndersonPayFunction
{
    public interface IFTypeOfService
    {
        #region CREATE
        TypeOfService Create(TypeOfService typeOfService);
        #endregion

        #region READ
        TypeOfService Read(int typeOfServiceId);
        List<TypeOfService> Read();
        #endregion

        #region Update
        TypeOfService Update(TypeOfService typeOfService);
        #endregion

        #region DELETE
        void Delete(TypeOfService TypeOfService);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
