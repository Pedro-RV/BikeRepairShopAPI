using Supplier_Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface ISupplierContextProvider
    {
        void InitializeSupplierContext();

        SupplierContext GetSupplierContext();
    }
}
