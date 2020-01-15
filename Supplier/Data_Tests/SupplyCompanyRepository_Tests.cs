using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    class SupplyCompanyRepository_Tests
    {
        private SupplierContext dbContext;
        private ExceptionController exceptionController;

        public SupplyCompanyRepository_Tests()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            SupplyCompany supplyCompanyOne = new SupplyCompany("Ruedas Hermanos Carrasco", "123");
            SupplyCompany supplyCompanyTwo = new SupplyCompany("Tecnologia ComputerMax", "001");
            SupplyCompany supplyCompanyThree = new SupplyCompany("Ropa Osuna", "002");
            SupplyCompanyRepository supplyCompanyRepository = new SupplyCompanyRepository(dbContext, exceptionController);

            supplyCompanyRepository.Insert(supplyCompanyOne);
            supplyCompanyRepository.Insert(supplyCompanyTwo);
            supplyCompanyRepository.Insert(supplyCompanyThree);
        }

        [Test]
        public void Insert_Test()
        {
            SupplyCompany supplyCompanyAdd = new SupplyCompany("Pesas Cañada", "003");
            bool correct;
            SupplyCompanyRepository supplyCompanyRepository = new SupplyCompanyRepository(dbContext, exceptionController);

            correct = supplyCompanyRepository.Insert(supplyCompanyAdd);

            SupplyCompany supplyCompanyGotten = supplyCompanyRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, supplyCompanyAdd.SupplyCompanyName);
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, supplyCompanyAdd.TelephoneNum);

        }

        [Test]
        public void Read_Test()
        {
            SupplyCompanyRepository supplyCompanyRepository = new SupplyCompanyRepository(dbContext, exceptionController);

            SupplyCompany supplyCompanyGotten = supplyCompanyRepository.Read(3);

            Assert.AreEqual(supplyCompanyGotten.SupplyCompanyName, "Ropa Osuna");
            Assert.AreEqual(supplyCompanyGotten.TelephoneNum, "002");

        }

        [Test]
        public void Update_Test()
        {
            SupplyCompanyRepository supplyCompanyRepository = new SupplyCompanyRepository(dbContext, exceptionController);
            bool correct;
            SupplyCompany supplyCompanyGotten = supplyCompanyRepository.Read(2);

            supplyCompanyGotten.SupplyCompanyName = "Tecnologia RapidMax";
            supplyCompanyGotten.TelephoneNum = "555";

            correct = supplyCompanyRepository.Update(supplyCompanyGotten);

            SupplyCompany supplyCompanyCompare = supplyCompanyRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(supplyCompanyCompare.SupplyCompanyName, supplyCompanyGotten.SupplyCompanyName);
            Assert.AreEqual(supplyCompanyCompare.TelephoneNum, supplyCompanyGotten.TelephoneNum);

        }

        [Test]
        public void Delete_Test()
        {
            SupplyCompanyRepository supplyCompanyRepository = new SupplyCompanyRepository(dbContext, exceptionController);
            bool correct;
            SupplyCompany supplyCompanyGotten = supplyCompanyRepository.Read(1);

            correct = supplyCompanyRepository.Delete(supplyCompanyGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
