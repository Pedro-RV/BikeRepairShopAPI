using NUnit.Framework;
using Supplier_Data.Context;
using System.IO;

namespace Data_Tests
{
    [TestFixture]
    class AACleanDatabase
    {
        [Test]
        public void Clean()
        {
            //SupplierContextProvider supplierContextProvider = new SupplierContextProvider();
            //supplierContextProvider.InitializeSupplierContext();
            //supplierContextProvider.GetSupplierContext().Database.Delete();
            //supplierContextProvider.GetSupplierContext().Database.Create();

            string path = Path.GetFullPath("/Users/pjrodriguez/");
            string sourceFile = path + "New_Supplier_Database/Supplier_Data.Context.SupplierContext.mdf";
            string destFile = path + "Supplier_Data.Context.SupplierContext.mdf";
            string del = path + "Supplier_Data.Context.SupplierContext_log.ldf";
            File.Delete(del);
            File.Copy(sourceFile, destFile, true);

        }

    }
}
