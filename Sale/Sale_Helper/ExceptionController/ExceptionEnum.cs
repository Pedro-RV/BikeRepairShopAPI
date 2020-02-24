using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Helper.ExceptionController
{
    public enum ExceptionEnum
    {
        InvalidRequest = 1,
        NullObject = 2,
        ObjectNotFound = 3,
        NullDNI = 4,
        MistakenPrize = 5,
        MistakenCuantity = 6,
        NullPaymentMethodDescription = 7,
        NullTelephoneNum = 8,
        MethodNotExist = 9,
        AuthenticationError = 10,
        ActionNotCompleted = 11,
        ProductNotActive = 12
    }
}
