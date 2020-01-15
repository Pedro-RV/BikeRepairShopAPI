using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class AACleanDatabase
    {
        [Test]
        public void Clean()
        {
            //SupplierContextProvider.InitializeSupplierContext();
            //SupplierContextProvider.GetSupplierContext().Database.Delete();
            //SupplierContextProvider.GetSupplierContext().Database.Create();

            string path = Path.GetFullPath("../../../../../../");
            string sourceFile = path + "New_Supplier_Database/Supplier_Data.Context.SupplierContext.mdf";
            string destFile = path + "Supplier_Data.Context.SupplierContext.mdf";
            string del = path + "Supplier_Data.Context.SupplierContext_log.ldf";
            File.Delete(del);
            File.Copy(sourceFile, destFile, true);
            
        }

    }
}
