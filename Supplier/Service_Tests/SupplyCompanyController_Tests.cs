//using NUnit.Framework;
//using Supplier_Entities.EntityModel;
//using Supplier_Entities.Specific;
//using Supplier_Service.Controllers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Service_Tests
//{
//    [TestFixture]
//    class SupplyCompanyController_Tests
//    {
//        [TestFixtureSetUp]
//        public void Init()
//        {
//            SupplyCompanyController supplyCompanyController = new SupplyCompanyController();

//            supplyCompanyController.InsertSupplyCompany(new SupplyCompanySpecific("Ruedas Hermanos Carrasco", "123"));
//            supplyCompanyController.InsertSupplyCompany(new SupplyCompanySpecific("Tecnologia ComputerMax", "001"));
//            supplyCompanyController.InsertSupplyCompany(new SupplyCompanySpecific("Ropa Osuna", "002"));

//        }

//        [Test]
//        public void InsertSupplyCompany_Test()
//        {
//            SupplyCompanyController supplyCompanyController = new SupplyCompanyController();

//            String message = supplyCompanyController.InsertSupplyCompany(new SupplyCompanySpecific("Pesas Cañada", "003"));

//            SupplyCompany supplyCompanyGotten = supplyCompanyController.GetSupplyCompany(4);

//            Assert.AreEqual(message, "SupplyCompany introduced satisfactorily.");
//            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Pesas Cañada");
//            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "003");

//        }

//        [Test]
//        public void GetSupplyCompany_Test()
//        {
//            SupplyCompanyController supplyCompanyController = new SupplyCompanyController();

//            SupplyCompany supplyCompanyGotten = supplyCompanyController.GetSupplyCompany(1);

//            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Ruedas Hermanos Carrasco");
//            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "123");

//        }

//        [Test]
//        public void UpdateSupplyCompany_Test()
//        {
//            SupplyCompanyController supplyCompanyController = new SupplyCompanyController();

//            SupplyCompanySpecific change = new SupplyCompanySpecific();
//            change.SupplyCompanyId = 2;
//            change.SupplyCompanyName = "Tecnologia RapidMax";
//            change.TelephoneNum = "555";

//            String message = supplyCompanyController.UpdateSupplyCompany(change);

//            SupplyCompany supplyCompanyGotten = supplyCompanyController.GetSupplyCompany(2);

//            Assert.AreEqual(message, "SupplyCompany updated satisfactorily.");
//            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Tecnologia RapidMax");
//            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "555");

//        }

//        [Test]
//        public void DeleteSupplyCompany_Test()
//        {
//            SupplyCompanyController supplyCompanyController = new SupplyCompanyController();

//            String message = supplyCompanyController.DeleteSupplyCompany(3);

//            Assert.AreEqual(message, "SupplyCompany deleted satisfactorily.");

//        }
//    }
//}
