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
    class ShippingRepository_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Client aux = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            ProductType aux2 = new ProductType("Ruedas");
            Product aux3 = new Product("Ruedas Michelin", 50, 50, aux2);
            PaymentMethod aux4 = new PaymentMethod("Contrarrembolso");
            DateTime aux5 = new DateTime(2019, 12, 03, 9, 38, 00);
            Sale aux6 = new Sale(aux5, 5, aux, aux3, aux4);
            TransportCompany aux7 = new TransportCompany("Envi", "911");
            DateTime aux8 = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime aux9 = new DateTime(2019, 12, 04, 9, 00, 00);

            Shipping one = new Shipping(aux8, aux9, aux6, aux7);
            ShippingRepository start = new ShippingRepository();

            start.Insert(one);
            start.Insert(one);
            start.Insert(one);
        }

        [Test]
        public void Insert_Test()
        {
            Client aux = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            ProductType aux2 = new ProductType("Ruedas");
            Product aux3 = new Product("Ruedas Michelin", 50, 50, aux2);
            PaymentMethod aux4 = new PaymentMethod("Contrarrembolso");
            DateTime aux5 = new DateTime(2019, 12, 03, 9, 38, 00);
            Sale aux6 = new Sale(aux5, 5, aux, aux3, aux4);
            TransportCompany aux7 = new TransportCompany("Envi", "911");
            DateTime aux8 = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime aux9 = new DateTime(2019, 12, 04, 9, 00, 00);

            Shipping add = new Shipping(aux8, aux9, aux6, aux7);
            bool correct;
            ShippingRepository test = new ShippingRepository();

            correct = test.Insert(add);

            Shipping gotten = test.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(gotten.DepartureDate, add.DepartureDate);
            Assert.AreEqual(gotten.PackingTime, add.PackingTime);
            Assert.AreEqual(gotten.Sale, add.Sale);
            Assert.AreEqual(gotten.TransportCompany, add.TransportCompany);

        }

        [Test]
        public void Read_Test()
        {
            ShippingRepository test = new ShippingRepository();

            Shipping gotten = test.Read(3);

            DateTime see1 = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime see2 = new DateTime(2019, 12, 04, 9, 00, 00);

            Assert.AreEqual(gotten.DepartureDate, see1);
            Assert.AreEqual(gotten.PackingTime, see2);

        }

        [Test]
        public void Update_Test()
        {
            ShippingRepository test = new ShippingRepository();
            bool correct;
            Shipping gotten = test.Read(2);

            DateTime change1 = new DateTime(2019, 12, 05, 9, 45, 00);
            DateTime change2 = new DateTime(2019, 12, 05, 9, 00, 00);

            gotten.DepartureDate = change1;
            gotten.PackingTime = change2;

            correct = test.Update(test.Read(2), gotten);

            Shipping compare = test.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(compare.DepartureDate, gotten.DepartureDate);
            Assert.AreEqual(compare.PackingTime, gotten.PackingTime);

        }

        [Test]
        public void Delete_Test()
        {
            ShippingRepository test = new ShippingRepository();
            bool correct;
            Shipping gotten = test.Read(1);

            correct = test.Delete(gotten);

            Assert.AreEqual(true, correct);

        }
    }
}
