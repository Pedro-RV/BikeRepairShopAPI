using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Helper.ExceptionController
{
    public class ExceptionController : IExceptionController
    {
        public SaleException CreateMyException(ExceptionEnum exNum)
        {
            ExceptionEnumText enum_message = new ExceptionEnumText();
            string message = enum_message.ObtainText((int)exNum);

            SaleException myEx = new SaleException(message);

            return myEx;
        }



        //public Exception CreateGeneralException(Exception ex)
        //{
        //    int exNum = (int)ExceptionEnum.InvalidRequest;
        //    ExceptionEnumText enum_message = new ExceptionEnumText();
        //    string message = enum_message.ObtainText(exNum);

        //    SaleException obtainEx = new SaleException();

        //    Exception myEx = obtainEx.MyException(ex, message);

        //    return myEx;
        //}

        //public Exception CreateOwnException(int exNum, Exception ex)
        //{
        //    ExceptionEnumText enum_message = new ExceptionEnumText();
        //    string message = enum_message.ObtainText(exNum);

        //    SaleException myEx = new SaleException(message, ex);

        //    return myEx;
        //}




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
