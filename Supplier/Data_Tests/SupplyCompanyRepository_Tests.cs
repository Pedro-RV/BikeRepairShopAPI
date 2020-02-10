using Autofac;
using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class SupplyCompanyRepository_Tests
    {
        private ISupplyCompanyRepository supplyCompanyRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.supplyCompanyRepository = scope.Resolve<ISupplyCompanyRepository>();

            SupplyCompany supplyCompanyOne = new SupplyCompany("Ruedas Hermanos Carrasco", "123");
            SupplyCompany supplyCompanyTwo = new SupplyCompany("Tecnologia ComputerMax", "001");
            SupplyCompany supplyCompanyThree = new SupplyCompany("Ropa Osuna", "002");

            this.supplyCompanyRepository.Insert(supplyCompanyOne);
            this.supplyCompanyRepository.Insert(supplyCompanyTwo);
            this.supplyCompanyRepository.Insert(supplyCompanyThree);
        }

        [Test]
        public void Insert_Test()
        {
            SupplyCompany supplyCompanyAdd = new SupplyCompany("Pesas Cañada", "003");
            bool correct;

            correct = this.supplyCompanyRepository.Insert(supplyCompanyAdd);

            SupplyCompany supplyCompanyGotten = this.supplyCompanyRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, supplyCompanyAdd.SupplyCompanyName);
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, supplyCompanyAdd.TelephoneNum);

        }

        [Test]
        public void Read_Test()
        {
            SupplyCompany supplyCompanyGotten = this.supplyCompanyRepository.Read(3);

            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Ropa Osuna");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "002");

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            SupplyCompany supplyCompanyGotten = this.supplyCompanyRepository.Read(2);

            supplyCompanyGotten.SupplyCompanyName = "Tecnologia RapidMax";
            supplyCompanyGotten.TelephoneNum = "555";

            correct = this.supplyCompanyRepository.Update(supplyCompanyGotten);

            SupplyCompany supplyCompanyCompare = this.supplyCompanyRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(supplyCompanyCompare.SupplyCompanyName, supplyCompanyGotten.SupplyCompanyName);
            Assert.AreEqual(supplyCompanyCompare.TelephoneNum, supplyCompanyGotten.TelephoneNum);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            SupplyCompany supplyCompanyGotten = this.supplyCompanyRepository.Read(1);

            correct = this.supplyCompanyRepository.Delete(supplyCompanyGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
