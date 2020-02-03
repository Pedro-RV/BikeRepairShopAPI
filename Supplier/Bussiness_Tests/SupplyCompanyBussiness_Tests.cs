//using NUnit.Framework;
//using Supplier_Bussiness;
//using Supplier_Entities.EntityModel;
//using Supplier_Entities.Specific;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bussiness_Tests
//{
//    [TestFixture]
//    class SupplyCompanyBussiness_Tests
//    {
//        [TestFixtureSetUp]
//        public void Init()
//        {
//            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

//            supplyCompanyBussiness.InsertSupplyCompany(new SupplyCompanySpecific("Ruedas Hermanos Carrasco", "123"));
//            supplyCompanyBussiness.InsertSupplyCompany(new SupplyCompanySpecific("Tecnologia ComputerMax", "001"));
//            supplyCompanyBussiness.InsertSupplyCompany(new SupplyCompanySpecific("Ropa Osuna", "002"));

//        }

//        [Test]
//        public void InsertSupplyCompany_Test()
//        {
//            bool correct;
//            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

//            correct = supplyCompanyBussiness.InsertSupplyCompany(new SupplyCompanySpecific("Pesas Cañada", "003"));

//            SupplyCompany supplyCompanyGotten = supplyCompanyBussiness.ReadSupplyCompany(4);

//            Assert.AreEqual(true, correct);
//            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Pesas Cañada");
//            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "003");

//        }

//        [Test]
//        public void ReadSupplyCompany_Test()
//        {
//            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

//            SupplyCompany supplyCompanyGotten = supplyCompanyBussiness.ReadSupplyCompany(1);

//            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Ruedas Hermanos Carrasco");
//            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "123");

//        }

//        [Test]
//        public void UpdateSupplyCompany_Test()
//        {
//            bool correct;
//            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

//            SupplyCompanySpecific change = new SupplyCompanySpecific();
//            change.SupplyCompanyId = 2;
//            change.SupplyCompanyName = "Tecnologia RapidMax";
//            change.TelephoneNum = "555";

//            correct = supplyCompanyBussiness.UpdateSupplyCompany(change);

//            SupplyCompany supplyCompanyGotten = supplyCompanyBussiness.ReadSupplyCompany(2);

//            Assert.AreEqual(true, correct);
//            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Tecnologia RapidMax");
//            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "555");

//        }

//        [Test]
//        public void DeleteSupplyCompany_Test()
//        {
//            bool correct;
//            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

//            correct = supplyCompanyBussiness.DeleteSupplyCompany(3);

//            Assert.AreEqual(true, correct);

//        }
//    }
//}
