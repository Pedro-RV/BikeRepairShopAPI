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
    class ClientRepository_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Client one = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            Client two = new Client("Rodolfo", "Suarez", "88", "rodolf@correo", "Avnd Institucion", "123", "321");
            Client three = new Client("Marco", "Polo", "99", "marco@correo", "Avnd Marco Polo", "000", "000");
            ClientRepository start = new ClientRepository();

            start.Insert(one);
            start.Insert(two);
            start.Insert(three);
        }

        [Test]
        public void Insert_Test()
        {
            Client add = new Client("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87");
            bool correct;
            ClientRepository test = new ClientRepository();

            correct = test.Insert(add);

            Client gotten = test.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(gotten.ClientName, add.ClientName);
            Assert.AreEqual(gotten.Surname, add.Surname);
            Assert.AreEqual(gotten.Email, add.Email);
            Assert.AreEqual(gotten.ClientAddress, add.ClientAddress);
            Assert.AreEqual(gotten.CP, add.CP);
            Assert.AreEqual(gotten.MobileNum, add.MobileNum);

        }

        [Test]
        public void Read_Test()
        {
            ClientRepository test = new ClientRepository();

            Client gotten = test.Read(3);

            Assert.AreEqual(gotten.ClientName, "Marco");
            Assert.AreEqual(gotten.Email, "marco@correo");

        }

        [Test]
        public void Update_Test()
        {
            ClientRepository test = new ClientRepository();
            bool correct;
            Client gotten = test.Read(2);

            gotten.ClientName = "Domingo";
            gotten.MobileNum = "621";

            correct = test.Update(test.Read(2), gotten);

            Client compare = test.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(compare.ClientName, gotten.ClientName);
            Assert.AreEqual(compare.MobileNum, gotten.MobileNum);

        }

        [Test]
        public void Delete_Test()
        {
            ClientRepository test = new ClientRepository();
            bool correct;
            Client gotten = test.Read(1);

            correct = test.Delete(gotten);

            Assert.AreEqual(true, correct);

        }
    }
}
