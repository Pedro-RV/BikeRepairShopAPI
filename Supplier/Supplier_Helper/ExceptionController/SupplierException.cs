using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Helper.ExceptionController
{
    public class SupplierException : Exception
    {
        public SupplierException()
        {

        }

        public SupplierException(string message)
        : base(message)
        {
        }

        public SupplierException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
