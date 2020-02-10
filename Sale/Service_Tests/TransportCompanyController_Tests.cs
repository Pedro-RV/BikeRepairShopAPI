using Autofac;
using NUnit.Framework;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using Sale_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tests
{
    [TestFixture]
    class TransportCompanyController_Tests
    {
        private TransportCompanyController transportCompanyController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.transportCompanyController = scope.Resolve<TransportCompanyController>();

            this.transportCompanyController.InsertTransportCompany(new TransportCompanySpecific("Envi", "911"));
            this.transportCompanyController.InsertTransportCompany(new TransportCompanySpecific("Correos", "912"));
            this.transportCompanyController.InsertTransportCompany(new TransportCompanySpecific("DHL", "913"));

        }

        [Test]
        public void InsertTransportCompany_Test()
        {
            string message = this.transportCompanyController.InsertTransportCompany(new TransportCompanySpecific("ShipEx", "914"));

            TransportCompany transportCompanyGotten = this.transportCompanyController.GetTransportCompany(4);

            Assert.AreEqual(message, "TransportCompany introduced satisfactorily.");
            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, "ShipEx");
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, "914");

        }

        [Test]
        public void GetTransportCompany_Test()
        {
            TransportCompany transportCompanyGotten = this.transportCompanyController.GetTransportCompany(1);

            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, "Envi");
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, "911");

        }

        [Test]
        public void UpdateTransportCompany_Test()
        {
            TransportCompanySpecific change = new TransportCompanySpecific();
            change.TransportCompanyId = 2;
            change.TransportCompanyName = "Seur";
            change.TelephoneNum = "900";

            string message = this.transportCompanyController.UpdateTransportCompany(change);

            TransportCompany transportCompanyCompare = this.transportCompanyController.GetTransportCompany(2);

            Assert.AreEqual(message, "TransportCompany updated satisfactorily.");
            Assert.AreEqual(transportCompanyCompare.TransportCompanyName, change.TransportCompanyName);
            Assert.AreEqual(transportCompanyCompare.TelephoneNum, change.TelephoneNum);

        }

        [Test]
        public void DeleteTransportCompany_Test()
        {
            string message = this.transportCompanyController.DeleteTransportCompany(3);

            Assert.AreEqual(message, "TransportCompany deleted satisfactorily.");

        }
    }
}
