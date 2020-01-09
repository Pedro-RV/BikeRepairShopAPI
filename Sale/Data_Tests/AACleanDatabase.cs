﻿using NUnit.Framework;
using Sale_Data.Context;
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
            //SaleContextProvider.InitializeSaleContext();
            //SaleContextProvider.GetSaleContext().Database.Delete();
            //SaleContextProvider.GetSaleContext().Database.Create();

            string sourceFile = @"C:\Users\pjrodriguez\New_Sale_Database\Sale_Data.Context.SaleContext.mdf";
            string destFile = @"C:\Users\pjrodriguez\Sale_Data.Context.SaleContext.mdf";
            string del = @"C:\Users\pjrodriguez\Sale_Data.Context.SaleContext_log.ldf";
            File.Delete(del);
            File.Copy(sourceFile, destFile, true);
        }
    }
}
