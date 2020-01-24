using NUnit.Framework;
using System.IO;

namespace Bussiness_Tests
{
    [TestFixture]
    class AACleanDatabase
    {
        [Test]
        public void Clean()
        {
            string path = Path.GetFullPath("/Users/pjrodriguez/");
            string sourceFile = path + "New_Supplier_Database/Supplier_Data.Context.SupplierContext.mdf";
            string destFile = path + "Supplier_Data.Context.SupplierContext.mdf";
            string del = path + "Supplier_Data.Context.SupplierContext_log.ldf";
            File.Delete(del);
            File.Copy(sourceFile, destFile, true);

        }
    }
}
