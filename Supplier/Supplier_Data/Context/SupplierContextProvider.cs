using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Context
{
    public class SupplierContextProvider
    {
        private static SupplierContext _instance;

        public SupplierContextProvider()
        {
        }

        public static void InitializeSupplierContext()
        {
            if(_instance == null)
            {
                _instance = new SupplierContext();
            }               
        }

        public static SupplierContext GetSupplierContext()
        {
            return _instance;
        }

    }
}