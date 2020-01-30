using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tests
{
    [TestFixture]
    class AACleanDatabase
    {
        [Test]
        public void Clean()
        {
            string path = Path.GetFullPath("/Users/pjrodriguez/");
            string sourceFile = path + "New_Sale_Database/Sale_Data.Context.SaleContext.mdf";
            string destFile = path + "Sale_Data.Context.SaleContext.mdf";
            string del = path + "Sale_Data.Context.SaleContext_log.ldf";
            File.Delete(del);
            File.Copy(sourceFile, destFile, true);

        }
    }
}
