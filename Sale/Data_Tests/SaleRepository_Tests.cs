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
    class SaleRepository_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Client aux = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            ProductType aux2 = new ProductType("Ruedas");
            Product aux3 = new Product("Ruedas Michelin", 50, 50, aux2);
            PaymentMethod aux4 = new PaymentMethod("Contrarrembolso");

            DateTime aux5 = new DateTime(2019, 12, 03, 9, 38, 00);

            Sale one = new Sale(aux5, 5, aux, aux3, aux4);
            Sale two = new Sale(aux5, 15, aux, aux3, aux4);
            Sale three = new Sale(aux5, 20, aux, aux3, aux4);
            SaleRepository start = new SaleRepository();

            start.Insert(one);
            start.Insert(two);
            start.Insert(three);
        }

        [Test]
        public void Insert_Test()
        {
            Client aux = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            ProductType aux2 = new ProductType("Ruedas");
            Product aux3 = new Product("Ruedas Michelin", 50, 50, aux2);
            PaymentMethod aux4 = new PaymentMethod("Contrarrembolso");
            DateTime aux5 = new DateTime(2019, 12, 03, 9, 38, 00);

            Sale add = new Sale(aux5, 50, aux, aux3, aux4);
            bool correct;
            SaleRepository test = new SaleRepository();

            correct = test.Insert(add);

            Sale gotten = test.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(gotten.SaleDate, add.SaleDate);
            Assert.AreEqual(gotten.Cuantity, add.Cuantity);
            Assert.AreEqual(gotten.Client, add.Client);
            Assert.AreEqual(gotten.Product, add.Product);
            Assert.AreEqual(gotten.PaymentMethod, add.PaymentMethod);

        }

        [Test]
        public void Read_Test()
        {
            SaleRepository test = new SaleRepository();

            Sale gotten = test.Read(3);

            DateTime see = new DateTime(2019, 12, 03, 9, 38, 00);

            Assert.AreEqual(gotten.SaleDate, see);
            Assert.AreEqual(gotten.Cuantity, 20);

        }

        [Test]
        public void Update_Test()
        {
            SaleRepository test = new SaleRepository();
            bool correct;
            Sale gotten = test.Read(2);

            gotten.Cuantity = 22;

            correct = test.Update(test.Read(2), gotten);

            Sale compare = test.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(compare.Cuantity, gotten.Cuantity);

        }

        [Test]
        public void Delete_Test()
        {
            SaleRepository test = new SaleRepository();
            bool correct;
            Sale gotten = test.Read(1);

            correct = test.Delete(gotten);

            Assert.AreEqual(true, correct);

        }
    }
}
