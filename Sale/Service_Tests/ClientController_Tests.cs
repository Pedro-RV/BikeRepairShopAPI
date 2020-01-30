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
    class ClientController_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            ClientController clientController = new ClientController();

            clientController.InsertClient(new ClientSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            clientController.InsertClient(new ClientSpecific("Rodolfo", "Suarez", "88", "rodolf@correo", "Avnd Institucion", "123", "321"));
            clientController.InsertClient(new ClientSpecific("Marco", "Polo", "99", "marco@correo", "Avnd Marco Polo", "000", "000"));

        }

        [Test]
        public void InsertClient_Test()
        {
            ClientController clientController = new ClientController();

            String message = clientController.InsertClient(new ClientSpecific("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87"));

            Client clientGotten = clientController.GetClient(4);

            Assert.AreEqual(message, "Client introduced satisfactorily.");
            Assert.AreEqual(clientGotten.ClientName, "antonio");
            Assert.AreEqual(clientGotten.Surname, "carrasco");
            Assert.AreEqual(clientGotten.DNI, "22");
            Assert.AreEqual(clientGotten.Email, "carrasco@correo");
            Assert.AreEqual(clientGotten.ClientAddress, "calle malagon");
            Assert.AreEqual(clientGotten.CP, "56");
            Assert.AreEqual(clientGotten.MobileNum, "87");

        }

        [Test]
        public void GetClient_Test()
        {
            ClientController clientController = new ClientController();

            Client clientGotten = clientController.GetClient(3);

            Assert.AreEqual(clientGotten.ClientName, "Marco");
            Assert.AreEqual(clientGotten.Email, "marco@correo");

        }

        [Test]
        public void UpdateClient_Test()
        {
            ClientController clientController = new ClientController();

            ClientSpecific change = new ClientSpecific();
            change.ClientId = 2;
            change.ClientName = "Domingo";
            change.MobileNum = "621";

            String message = clientController.UpdateClient(change);

            Client clientCompare = clientController.GetClient(2);

            Assert.AreEqual(message, "Client updated satisfactorily.");
            Assert.AreEqual(clientCompare.ClientName, change.ClientName);
            Assert.AreEqual(clientCompare.MobileNum, change.MobileNum);

        }

        [Test]
        public void DeleteClient_Test()
        {
            ClientController clientController = new ClientController();

            String message = clientController.DeleteClient(1);

            Assert.AreEqual(message, "Client deleted satisfactorily.");
        }

    }
}
