using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Helper.ExceptionController
{
    public enum ExceptionEnum
    {
        InvalidRequest = 1,
        NullObject = 2,
        ObjectNotFound = 3,
        NullDNI = 4,
        MistakenPrize = 5,
        MistakenCuantity = 6,
        NullTelephoneNum = 7,
        NullWarehouseAddress = 8,
        MethodNotExist = 9,
        AuthenticationError = 10,
        ActionNotCompleted = 11,
        NullProductTypeDescription = 12,

    }
}
