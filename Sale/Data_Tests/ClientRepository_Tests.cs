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
    class ClientRepository_Tests
    {
        private IClientRepository clientRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.clientRepository = scope.Resolve<IClientRepository>();

            Client clientOne = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            Client clientTwo = new Client("Rodolfo", "Suarez", "88", "rodolf@correo", "Avnd Institucion", "123", "321");
            Client clientThree = new Client("Marco", "Polo", "99", "marco@correo", "Avnd Marco Polo", "000", "000");

            this.clientRepository.Insert(clientOne);
            this.clientRepository.Insert(clientTwo);
            this.clientRepository.Insert(clientThree);
        }

        [Test]
        public void Insert_Test()
        {
            Client clientAdd = new Client("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87");
            bool correct;

            correct = this.clientRepository.Insert(clientAdd);

            Client clientGotten = this.clientRepository.Read(4);

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
            Client clientGotten = this.clientRepository.Read(1);

            Assert.AreEqual(clientGotten.ClientName, "Jacinto");
            Assert.AreEqual(clientGotten.Email, "sierra@correo");

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            Client clientGotten = this.clientRepository.Read(2);

            clientGotten.ClientName = "Domingo";
            clientGotten.MobileNum = "621";

            correct = this.clientRepository.Update(clientGotten);

            Client clientCompare = this.clientRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(clientCompare.ClientName, clientGotten.ClientName);
            Assert.AreEqual(clientCompare.MobileNum, clientGotten.MobileNum);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            Client clientGotten = this.clientRepository.Read(3);

            correct = this.clientRepository.Delete(clientGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
