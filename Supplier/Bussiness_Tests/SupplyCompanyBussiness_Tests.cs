using Autofac;
using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Tests
{
    [TestFixture]
    class SupplyCompanyBussiness_Tests
    {
        private ISupplyCompanyBussiness supplyCompanyBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.supplyCompanyBussiness = scope.Resolve<ISupplyCompanyBussiness>();

            this.supplyCompanyBussiness.InsertSupplyCompany(new SupplyCompanySpecific("Ruedas Hermanos Carrasco", "123"));
            this.supplyCompanyBussiness.InsertSupplyCompany(new SupplyCompanySpecific("Tecnologia ComputerMax", "001"));
            this.supplyCompanyBussiness.InsertSupplyCompany(new SupplyCompanySpecific("Ropa Osuna", "002"));

        }

        [Test]
        public void InsertSupplyCompany_Test()
        {
            bool correct;

            correct = this.supplyCompanyBussiness.InsertSupplyCompany(new SupplyCompanySpecific("Pesas Cañada", "003"));

            SupplyCompany supplyCompanyGotten = this.supplyCompanyBussiness.ReadSupplyCompany(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Pesas Cañada");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "003");

        }

        [Test]
        public void ReadSupplyCompany_Test()
        {
            SupplyCompany supplyCompanyGotten = this.supplyCompanyBussiness.ReadSupplyCompany(1);

            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Ruedas Hermanos Carrasco");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "123");

        }

        [Test]
        public void UpdateSupplyCompany_Test()
        {
            bool correct;

            SupplyCompanySpecific change = new SupplyCompanySpecific();
            change.SupplyCompanyId = 2;
            change.SupplyCompanyName = "Tecnologia RapidMax";
            change.TelephoneNum = "555";

            correct = this.supplyCompanyBussiness.UpdateSupplyCompany(change);

            SupplyCompany supplyCompanyGotten = this.supplyCompanyBussiness.ReadSupplyCompany(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Tecnologia RapidMax");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "555");

        }

        [Test]
        public void DeleteSupplyCompany_Test()
        {
            bool correct;

            correct = this.supplyCompanyBussiness.DeleteSupplyCompany(3);

            Assert.AreEqual(true, correct);

        }
    }
}
