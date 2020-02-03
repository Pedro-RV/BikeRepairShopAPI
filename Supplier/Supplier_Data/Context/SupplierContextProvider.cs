using Supplier_Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Context
{
    public class SupplierContextProvider : ISupplierContextProvider
    {
        private static SupplierContext _instance;

        public SupplierContextProvider()
        {
        }

        public void InitializeSupplierContext()
        {
            if(_instance == null)
            {
                _instance = new SupplierContext();
            }               
        }

        public SupplierContext GetSupplierContext()
        {
            return _instance;
        }

    }
}