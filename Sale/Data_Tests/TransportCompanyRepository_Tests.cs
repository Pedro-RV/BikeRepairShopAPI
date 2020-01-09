using NUnit.Framework;
using Sale_Data;
using Sale_Entities.EntityModel;
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
        [TestFixtureSetUp]
        public void Init()
        {
            TransportCompany one = new TransportCompany("Envi", "911");
            TransportCompany two = new TransportCompany("Correos", "912");
            TransportCompany three = new TransportCompany("DHL", "913");
            TransportCompanyRepository start = new TransportCompanyRepository();

            start.Insert(one);
            start.Insert(two);
            start.Insert(three);
        }

        [Test]
        public void Insert_Test()
        {
            TransportCompany add = new TransportCompany("ShipEx", "914");
            bool correct;
            TransportCompanyRepository test = new TransportCompanyRepository();

            correct = test.Insert(add);

            TransportCompany gotten = test.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(gotten.TransportCompanyName, add.TransportCompanyName);
            Assert.AreEqual(gotten.TelephoneNum, add.TelephoneNum);

        }

        [Test]
        public void Read_Test()
        {
            TransportCompanyRepository test = new TransportCompanyRepository();

            TransportCompany gotten = test.Read(3);

            Assert.AreEqual(gotten.TransportCompanyName, "DHL");
            Assert.AreEqual(gotten.TelephoneNum, "913");

        }

        [Test]
        public void Update_Test()
        {
            TransportCompanyRepository test = new TransportCompanyRepository();
            bool correct;
            TransportCompany gotten = test.Read(2);

            gotten.TransportCompanyName = "Seur";
            gotten.TelephoneNum = "900";

            correct = test.Update(test.Read(2), gotten);

            TransportCompany compare = test.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(compare.TransportCompanyName, gotten.TransportCompanyName);
            Assert.AreEqual(compare.TelephoneNum, gotten.TelephoneNum);

        }

        [Test]
        public void Delete_Test()
        {
            TransportCompanyRepository test = new TransportCompanyRepository();
            bool correct;
            TransportCompany gotten = test.Read(1);

            correct = test.Delete(gotten);

            Assert.AreEqual(true, correct);

        }
    }
}
