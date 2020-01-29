using NUnit.Framework;
using Sale_Data;
using Sale_Data.Context;
using Sale_Entities.EntityModel;
using Sale_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class TransportCompanyRepository_Tests
    {
        private SaleContext dbContext;
        private ExceptionController exceptionController;

        public TransportCompanyRepository_Tests()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            TransportCompany transportCompanyOne = new TransportCompany("Envi", "911");
            TransportCompany transportCompanyTwo = new TransportCompany("Correos", "912");
            TransportCompany transportCompanyThree = new TransportCompany("DHL", "913");
            TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository(dbContext, exceptionController);

            transportCompanyRepository.Insert(transportCompanyOne);
            transportCompanyRepository.Insert(transportCompanyTwo);
            transportCompanyRepository.Insert(transportCompanyThree);
        }

        [Test]
        public void Insert_Test()
        {
            TransportCompany transportCompanyAdd = new TransportCompany("ShipEx", "914");
            bool correct;
            TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository(dbContext, exceptionController);

            correct = transportCompanyRepository.Insert(transportCompanyAdd);

            TransportCompany transportCompanyGotten = transportCompanyRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, transportCompanyAdd.TransportCompanyName);
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, transportCompanyAdd.TelephoneNum);

        }

        [Test]
        public void Read_Test()
        {
            TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository(dbContext, exceptionController);

            TransportCompany transportCompanyGotten = transportCompanyRepository.Read(3);

            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, "DHL");
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, "913");

        }

        [Test]
        public void Update_Test()
        {
            TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository(dbContext, exceptionController);
            bool correct;
            TransportCompany transportCompanyGotten = transportCompanyRepository.Read(2);

            transportCompanyGotten.TransportCompanyName = "Seur";
            transportCompanyGotten.TelephoneNum = "900";

            correct = transportCompanyRepository.Update(transportCompanyGotten);

            TransportCompany transportCompanyCompare = transportCompanyRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(transportCompanyCompare.TransportCompanyName, transportCompanyGotten.TransportCompanyName);
            Assert.AreEqual(transportCompanyCompare.TelephoneNum, transportCompanyGotten.TelephoneNum);

        }

        [Test]
        public void Delete_Test()
        {
            TransportCompanyRepository transportCompanyRepository = new TransportCompanyRepository(dbContext, exceptionController);
            bool correct;
            TransportCompany transportCompanyGotten = transportCompanyRepository.Read(1);

            correct = transportCompanyRepository.Delete(transportCompanyGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
