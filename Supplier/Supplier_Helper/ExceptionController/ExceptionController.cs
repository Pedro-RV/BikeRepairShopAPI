using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Helper.ExceptionController
{
    public class ExceptionController : IExceptionController
    {
        public SupplierException CreateMyException(ExceptionEnum exNum)
        {
            ExceptionEnumText enum_message = new ExceptionEnumText();
            string message = enum_message.ObtainText((int)exNum);

            SupplierException myEx = new SupplierException(message, "hola");

            return myEx;
        }

        //private int ObtainExceptionEnum(Exception ex)
        //{
        //    int ret = 0;
        //    NullReferenceException a = new NullReferenceException();

        //    if (ex.GetType() == a.GetType())
        //    {
        //        ret = (int)ExceptionEnum.NullObject;
        //    }

        //    return ret;

        //}
            
    }
}
