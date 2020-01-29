using NUnit.Framework;
using Sale_Bussiness;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Tests
{
    [TestFixture]
    class TransportCompanyBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();

            transportCompanyBussiness.InsertTransportCompany(new TransportCompanySpecific("Envi", "911"));
            transportCompanyBussiness.InsertTransportCompany(new TransportCompanySpecific("Correos", "912"));
            transportCompanyBussiness.InsertTransportCompany(new TransportCompanySpecific("DHL", "913"));

        }

        [Test]
        public void InsertClient_Test()
        {
            bool correct;
            TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();

            correct = transportCompanyBussiness.InsertTransportCompany(new TransportCompanySpecific("ShipEx", "914"));

            TransportCompany transportCompanyGotten = transportCompanyBussiness.ReadTransportCompany(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, "ShipEx");
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, "914");

        }

        [Test]
        public void ReadClient_Test()
        {
            TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();

            TransportCompany transportCompanyGotten = transportCompanyBussiness.ReadTransportCompany(3);

            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, "DHL");
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, "913");

        }

        [Test]
        public void UpdateClient_Test()
        {
            TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();
            bool correct;

            TransportCompanySpecific change = new TransportCompanySpecific();
            change.TransportCompanyId = 2;
            change.TransportCompanyName = "Seur";
            change.TelephoneNum = "900";

            correct = transportCompanyBussiness.UpdateTransportCompany(change);

            TransportCompany transportCompanyCompare = transportCompanyBussiness.ReadTransportCompany(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(transportCompanyCompare.TransportCompanyName, change.TransportCompanyName);
            Assert.AreEqual(transportCompanyCompare.TelephoneNum, change.TelephoneNum);

        }

        [Test]
        public void DeleteClient_Test()
        {
            TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();
            bool correct;

            correct = transportCompanyBussiness.DeleteTransportCompany(1);

            Assert.AreEqual(true, correct);

        }
    }
}
