using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Entities.EntityModel;
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
        [TestFixtureSetUp]
        public void Init()
        {
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            supplyCompanyBussiness.InsertSupplyCompany("Ruedas Hermanos Carrasco", "123");
            supplyCompanyBussiness.InsertSupplyCompany("Tecnologia ComputerMax", "001");
            supplyCompanyBussiness.InsertSupplyCompany("Ropa Osuna", "002");

        }

        [Test]
        public void Insert_Test()
        {
            bool correct;
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            correct = supplyCompanyBussiness.InsertSupplyCompany("Pesas Cañada", "003");

            SupplyCompany supplyCompanyGotten = supplyCompanyBussiness.ReadSupplyCompany(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Pesas Cañada");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "003");

        }

        [Test]
        public void Read_Test()
        {
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            SupplyCompany supplyCompanyGotten = supplyCompanyBussiness.ReadSupplyCompany(1);

            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Ruedas Hermanos Carrasco");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "123");

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            correct = supplyCompanyBussiness.UpdateSupplyCompany(2, "Tecnologia RapidMax", "555");

            SupplyCompany supplyCompanyGotten = supplyCompanyBussiness.ReadSupplyCompany(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Tecnologia RapidMax");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "555");

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            correct = supplyCompanyBussiness.DeleteSupplyCompany(3);

            Assert.AreEqual(true, correct);

        }
    }
}
