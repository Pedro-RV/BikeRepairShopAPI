﻿using Autofac;
using NUnit.Framework;
using Sale_Bussiness;
using Sale_Bussiness.Interfaces;
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
        private ITransportCompanyBussiness transportCompanyBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.transportCompanyBussiness = scope.Resolve<ITransportCompanyBussiness>();

            this.transportCompanyBussiness.InsertTransportCompany(new TransportCompanySpecific("Envi", "911"));
            this.transportCompanyBussiness.InsertTransportCompany(new TransportCompanySpecific("Correos", "912"));
            this.transportCompanyBussiness.InsertTransportCompany(new TransportCompanySpecific("DHL", "913"));

        }

        [Test]
        public void InsertTransportCompany_Test()
        {
            bool correct;

            correct = this.transportCompanyBussiness.InsertTransportCompany(new TransportCompanySpecific("ShipEx", "914"));

            TransportCompany transportCompanyGotten = this.transportCompanyBussiness.ReadTransportCompany(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, "ShipEx");
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, "914");

        }

        [Test]
        public void ReadTransportCompany_Test()
        {
            TransportCompany transportCompanyGotten = this.transportCompanyBussiness.ReadTransportCompany(1);

            Assert.AreEqual(transportCompanyGotten.TransportCompanyName, "Envi");
            Assert.AreEqual(transportCompanyGotten.TelephoneNum, "911");

        }

        [Test]
        public void UpdateTransportCompany_Test()
        {
            bool correct;

            TransportCompanySpecific change = new TransportCompanySpecific();
            change.TransportCompanyId = 2;
            change.TransportCompanyName = "Seur";
            change.TelephoneNum = "900";

            correct = this.transportCompanyBussiness.UpdateTransportCompany(change);

            TransportCompany transportCompanyCompare = this.transportCompanyBussiness.ReadTransportCompany(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(transportCompanyCompare.TransportCompanyName, change.TransportCompanyName);
            Assert.AreEqual(transportCompanyCompare.TelephoneNum, change.TelephoneNum);

        }

        [Test]
        public void DeleteTransportCompany_Test()
        {
            bool correct;

            correct = this.transportCompanyBussiness.DeleteTransportCompany(3);

            Assert.AreEqual(true, correct);

        }
    }
}
