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
    class ClientBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            ClientBussiness clientBussiness = new ClientBussiness();

            clientBussiness.InsertClient(new ClientSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            clientBussiness.InsertClient(new ClientSpecific("Rodolfo", "Suarez", "88", "rodolf@correo", "Avnd Institucion", "123", "321"));
            clientBussiness.InsertClient(new ClientSpecific("Marco", "Polo", "99", "marco@correo", "Avnd Marco Polo", "000", "000"));

        }

        [Test]
        public void InsertClient_Test()
        {
            bool correct;
            ClientBussiness clientBussiness = new ClientBussiness();

            correct = clientBussiness.InsertClient(new ClientSpecific("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87"));

            Client clientGotten = clientBussiness.ReadClient(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(clientGotten.ClientName, "antonio");
            Assert.AreEqual(clientGotten.Surname, "carrasco");
            Assert.AreEqual(clientGotten.DNI, "22");
            Assert.AreEqual(clientGotten.Email, "carrasco@correo");
            Assert.AreEqual(clientGotten.ClientAddress, "calle malagon");
            Assert.AreEqual(clientGotten.CP, "56");
            Assert.AreEqual(clientGotten.MobileNum, "87");

        }

        [Test]
        public void ReadClient_Test()
        {
            ClientBussiness clientBussiness = new ClientBussiness();

            Client clientGotten = clientBussiness.ReadClient(3);

            Assert.AreEqual(clientGotten.ClientName, "Marco");
            Assert.AreEqual(clientGotten.Email, "marco@correo");

        }

        [Test]
        public void UpdateClient_Test()
        {
            ClientBussiness clientBussiness = new ClientBussiness();
            bool correct;

            ClientSpecific change = new ClientSpecific();
            change.ClientId = 2;
            change.ClientName = "Domingo";
            change.MobileNum = "621";

            correct = clientBussiness.UpdateClient(change);

            Client clientCompare = clientBussiness.ReadClient(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(clientCompare.ClientName, change.ClientName);
            Assert.AreEqual(clientCompare.MobileNum, change.MobileNum);

        }

        [Test]
        public void DeleteClient_Test()
        {
            ClientBussiness clientBussiness = new ClientBussiness();
            bool correct;

            correct = clientBussiness.DeleteClient(1);

            Assert.AreEqual(true, correct);

        }
    }
}
