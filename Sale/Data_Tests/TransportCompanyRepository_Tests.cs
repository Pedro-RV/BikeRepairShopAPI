using Autofac;
using NUnit.Framework;
using Sale_Data;
using Sale_Data.Context;
using Sale_Data.Interfaces;
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
        private ITransportCompanyRepository transportCompanyRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.transportCompanyRepository = scope.Resolve<ITransportCompanyRepository>();

            TransportCompany transportCompanyOne = new TransportCompany("Envi", "911");
            TransportCompany transportCompanyTwo = new TransportCompany("Correos", "912");
            TransportCompany transportCompanyThree = new TransportCompany("DHL", "913");

            this.transportCompanyRepository.Insert(transportCompanyOne);
            this.transportCompanyRepository.Insert(transportCompanyTwo);
            this.transportCompanyRepository.Insert(transportCompanyThree);
        }

        [Test]
        public void Insert_Test()
        {
            TransportCompany transportCompanyAdd = new TransportCompany("ShipEx", "914");
            bool correct;

            correct = this.transportCompanyRepository.Insert(transportCompanyAdd);

            TransportCompany transportCompanyGotten = this.transportCompanyRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, transportCompanyAdd.TransportCompanyName);
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, transportCompanyAdd.TelephoneNum);

        }

        [Test]
        public void Read_Test()
        {
            TransportCompany transportCompanyGotten = this.transportCompanyRepository.Read(1);

            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, "Envi");
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, "911");

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            TransportCompany transportCompanyGotten = this.transportCompanyRepository.Read(2);

            transportCompanyGotten.TransportCompanyName = "Seur";
            transportCompanyGotten.TelephoneNum = "900";

            correct = this.transportCompanyRepository.Update(transportCompanyGotten);

            TransportCompany transportCompanyCompare = this.transportCompanyRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(transportCompanyCompare.TransportCompanyName, transportCompanyGotten.TransportCompanyName);
            Assert.AreEqual(transportCompanyCompare.TelephoneNum, transportCompanyGotten.TelephoneNum);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            TransportCompany transportCompanyGotten = this.transportCompanyRepository.Read(3);

            correct = this.transportCompanyRepository.Delete(transportCompanyGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
