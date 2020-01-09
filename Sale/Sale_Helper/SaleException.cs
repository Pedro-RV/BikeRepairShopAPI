using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Helper.ExceptionController
{
    public class SaleException : Exception
    {
        public SaleException()
        {

        }

        public SaleException(string message)
        : base(message)
        {
        }

        public SaleException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public Exception MyException(Exception ex, string message)
        {
            Exception create = new Exception(message, ex);

            return create;
        }

    }
}
