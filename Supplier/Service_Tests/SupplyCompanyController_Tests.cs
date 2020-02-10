using Autofac;
using NUnit.Framework;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using Supplier_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tests
{
    [TestFixture]
    class SupplyCompanyController_Tests
    {
        private SupplyCompanyController supplyCompanyController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.supplyCompanyController = scope.Resolve<SupplyCompanyController>();

            this.supplyCompanyController.InsertSupplyCompany(new SupplyCompanySpecific("Ruedas Hermanos Carrasco", "123"));
            this.supplyCompanyController.InsertSupplyCompany(new SupplyCompanySpecific("Tecnologia ComputerMax", "001"));
            this.supplyCompanyController.InsertSupplyCompany(new SupplyCompanySpecific("Ropa Osuna", "002"));

        }

        [Test]
        public void InsertSupplyCompany_Test()
        {
            String message = this.supplyCompanyController.InsertSupplyCompany(new SupplyCompanySpecific("Pesas Cañada", "003"));

            SupplyCompany supplyCompanyGotten = this.supplyCompanyController.GetSupplyCompany(4);

            Assert.AreEqual(message, "SupplyCompany introduced satisfactorily.");
            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Pesas Cañada");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "003");

        }

        [Test]
        public void GetSupplyCompany_Test()
        {
            SupplyCompany supplyCompanyGotten = this.supplyCompanyController.GetSupplyCompany(1);

            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Ruedas Hermanos Carrasco");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "123");

        }

        [Test]
        public void UpdateSupplyCompany_Test()
        {
            SupplyCompanySpecific change = new SupplyCompanySpecific();
            change.SupplyCompanyId = 2;
            change.SupplyCompanyName = "Tecnologia RapidMax";
            change.TelephoneNum = "555";

            String message = this.supplyCompanyController.UpdateSupplyCompany(change);

            SupplyCompany supplyCompanyGotten = this.supplyCompanyController.GetSupplyCompany(2);

            Assert.AreEqual(message, "SupplyCompany updated satisfactorily.");
            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Tecnologia RapidMax");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "555");

        }

        [Test]
        public void DeleteSupplyCompany_Test()
        {
            String message = this.supplyCompanyController.DeleteSupplyCompany(3);

            Assert.AreEqual(message, "SupplyCompany deleted satisfactorily.");

        }
    }
}
