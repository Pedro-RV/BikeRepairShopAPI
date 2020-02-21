using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Helper.ExceptionController
{
    public class ExceptionEnumText
    {
        private const string InvalidRequest = "Invalid request.";
        private const string NullObject = "The object introduced has not data (null).";
        private const string ObjectNotFound = "The object does not exist.";
        private const string NullDNI = "The client must have a DNI.";
        private const string MistakenPrize = "The product's prize can not be 0 or lower.";
        private const string MistakenCuantity = "The cuantity can not be lower than 0.";
        private const string NullPaymentMethodDescription = "The payment method must have a description.";
        private const string NullTelephoneNum = "The transport company must have a telephone number.";
        private const string MethodNotExist = "The method invoked does not exist.";
        private const string AuthenticationError = "The user and/or pwd introduced are wrong.";
        private const string ActionNotCompleted = "Error !!! Action could not be completed.";


        public string ObtainText(int exNum)
        {
            string ret = null;

            if (exNum == 1)
            {
                ret = InvalidRequest;
            }

            if (exNum == 2)
            {
                ret = NullObject;
            }

            if (exNum == 3)
            {
                ret = ObjectNotFound;
            }

            if (exNum == 4)
            {
                ret = NullDNI;
            }

            if (exNum == 5)
            {
                ret = MistakenPrize;
            }

            if (exNum == 6)
            {
                ret = MistakenCuantity;
            }

            if (exNum == 7)
            {
                ret = NullPaymentMethodDescription;
            }            

            if (exNum == 8)
            {
                ret = NullTelephoneNum;
            }

            if (exNum == 9)
            {
                ret = MethodNotExist;
            }

            if (exNum == 10)
            {
                ret = AuthenticationError;
            }

            if (exNum == 11)
            {
                ret = ActionNotCompleted;
            }

            return ret;

        }

    }
}
