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
    class ClientRepository_Tests
    {
        private SaleContext dbContext;
        private ExceptionController exceptionController;

        public ClientRepository_Tests()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            Client clientOne = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            Client clientTwo = new Client("Rodolfo", "Suarez", "88", "rodolf@correo", "Avnd Institucion", "123", "321");
            Client clientThree = new Client("Marco", "Polo", "99", "marco@correo", "Avnd Marco Polo", "000", "000");
            ClientRepository clientRepository = new ClientRepository(dbContext, exceptionController);

            clientRepository.Insert(clientOne);
            clientRepository.Insert(clientTwo);
            clientRepository.Insert(clientThree);
        }

        [Test]
        public void Insert_Test()
        {
            Client clientAdd = new Client("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87");
            bool correct;
            ClientRepository clientRepository = new ClientRepository(dbContext, exceptionController);

            correct = clientRepository.Insert(clientAdd);

            Client clientGotten = clientRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(clientGotten.ClientName, clientAdd.ClientName);
            Assert.AreEqual(clientGotten.Surname, clientAdd.Surname);
            Assert.AreEqual(clientGotten.DNI, clientAdd.DNI);
            Assert.AreEqual(clientGotten.Email, clientAdd.Email);
            Assert.AreEqual(clientGotten.ClientAddress, clientAdd.ClientAddress);
            Assert.AreEqual(clientGotten.CP, clientAdd.CP);
            Assert.AreEqual(clientGotten.MobileNum, clientAdd.MobileNum);

        }

        [Test]
        public void Read_Test()
        {
            ClientRepository clientRepository = new ClientRepository(dbContext, exceptionController);

            Client clientGotten = clientRepository.Read(3);

            Assert.AreEqual(clientGotten.ClientName, "Marco");
            Assert.AreEqual(clientGotten.Email, "marco@correo");

        }

        [Test]
        public void Update_Test()
        {
            ClientRepository clientRepository = new ClientRepository(dbContext, exceptionController);
            bool correct;
            Client clientGotten = clientRepository.Read(2);

            clientGotten.ClientName = "Domingo";
            clientGotten.MobileNum = "621";

            correct = clientRepository.Update(clientGotten);

            Client clientCompare = clientRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(clientCompare.ClientName, clientGotten.ClientName);
            Assert.AreEqual(clientCompare.MobileNum, clientGotten.MobileNum);

        }

        [Test]
        public void Delete_Test()
        {
            ClientRepository clientRepository = new ClientRepository(dbContext, exceptionController);
            bool correct;
            Client clientGotten = clientRepository.Read(1);

            correct = clientRepository.Delete(clientGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
