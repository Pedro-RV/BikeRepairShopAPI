using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Helper.ExceptionController
{
    public interface IExceptionController
    {
        Exception CreateGeneralException(Exception ex);
        Exception CreateOwnException(int exNum, Exception ex);

    }
}
