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
        [TestFixtureSetUp]
        public void Init()
        {
            TransportCompanyController transportCompanyController = new TransportCompanyController();

            transportCompanyController.InsertTransportCompany(new TransportCompanySpecific("Envi", "911"));
            transportCompanyController.InsertTransportCompany(new TransportCompanySpecific("Correos", "912"));
            transportCompanyController.InsertTransportCompany(new TransportCompanySpecific("DHL", "913"));

        }

        [Test]
        public void InsertTransportCompany_Test()
        {
            TransportCompanyController transportCompanyController = new TransportCompanyController();

            string message = transportCompanyController.InsertTransportCompany(new TransportCompanySpecific("ShipEx", "914"));

            TransportCompany transportCompanyGotten = transportCompanyController.GetTransportCompany(4);

            Assert.AreEqual(message, "TransportCompany introduced satisfactorily.");
            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, "ShipEx");
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, "914");

        }

        [Test]
        public void GetTransportCompany_Test()
        {
            TransportCompanyController transportCompanyController = new TransportCompanyController();

            TransportCompany transportCompanyGotten = transportCompanyController.GetTransportCompany(3);

            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, "DHL");
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, "913");

        }

        [Test]
        public void UpdateTransportCompany_Test()
        {
            TransportCompanyController transportCompanyController = new TransportCompanyController();

            TransportCompanySpecific change = new TransportCompanySpecific();
            change.TransportCompanyId = 2;
            change.TransportCompanyName = "Seur";
            change.TelephoneNum = "900";

            string message = transportCompanyController.UpdateTransportCompany(change);

            TransportCompany transportCompanyCompare = transportCompanyController.GetTransportCompany(2);

            Assert.AreEqual(message, "TransportCompany updated satisfactorily.");
            Assert.AreEqual(transportCompanyCompare.TransportCompanyName, change.TransportCompanyName);
            Assert.AreEqual(transportCompanyCompare.TelephoneNum, change.TelephoneNum);

        }

        [Test]
        public void DeleteTransportCompany_Test()
        {
            TransportCompanyController transportCompanyController = new TransportCompanyController();

            string message = transportCompanyController.DeleteTransportCompany(1);

            Assert.AreEqual(message, "TransportCompany deleted satisfactorily.");

        }
    }
}
