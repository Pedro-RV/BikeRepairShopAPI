using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Helper.ExceptionController
{
    public interface IExceptionController
    {
        SupplierException CreateMyException(ExceptionEnum exNum);

    }
}
