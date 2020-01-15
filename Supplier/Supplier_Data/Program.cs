using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System.IO;
using System.Linq;

namespace Supplier_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            SupplierContext dbContext;

            ExceptionController exceptionController;

            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();

            EmployeeRepository a = new EmployeeRepository(dbContext, exceptionController);

            Employee b = a.Read(1);

        }
    }
}
