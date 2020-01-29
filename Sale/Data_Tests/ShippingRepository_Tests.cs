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
    class ShippingRepository_Tests
    {
        private SaleContext dbContext;
        private ExceptionController exceptionController;

        public ShippingRepository_Tests()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            Client client = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            ProductType productType = new ProductType("Ruedas");
            Product product = new Product("Ruedas Michelin", 50, 50, productType);
            PaymentMethod paymentMethod = new PaymentMethod("Contrarrembolso");
            DateTime dateTime = new DateTime(2019, 12, 03, 15, 12, 00);
            Bill bill = new Bill(dateTime, paymentMethod);
            Sale saleOne = new Sale(5, client, product, bill);
            TransportCompany transportCompany = new TransportCompany("Envi", "911");
            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            Shipping shipping = new Shipping(dateTimeDeparture, dateTimePacking, saleOne, transportCompany);
            ShippingRepository shippingRepository = new ShippingRepository(dbContext, exceptionController);

            shippingRepository.Insert(shipping);
            shippingRepository.Insert(shipping);
            shippingRepository.Insert(shipping);
        }

        [Test]
        public void Insert_Test()
        {
            Client client = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            ProductType productType = new ProductType("Ruedas");
            Product product = new Product("Ruedas Michelin", 50, 50, productType);
            PaymentMethod paymentMethod = new PaymentMethod("Contrarrembolso");
            DateTime dateTime = new DateTime(2019, 12, 03, 15, 12, 00);
            Bill bill = new Bill(dateTime, paymentMethod);
            Sale saleOne = new Sale(5, client, product, bill);
            TransportCompany transportCompany = new TransportCompany("Envi", "911");
            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            Shipping shippingAdd = new Shipping(dateTimeDeparture, dateTimePacking, saleOne, transportCompany);
            bool correct;
            ShippingRepository shippingRepository = new ShippingRepository(dbContext, exceptionController);

            correct = shippingRepository.Insert(shippingAdd);

            Shipping shippingGotten = shippingRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(shippingGotten.DepartureDate, shippingAdd.DepartureDate);
            Assert.AreEqual(shippingGotten.PackingTime, shippingAdd.PackingTime);
            Assert.AreEqual(shippingGotten.Sale, shippingAdd.Sale);
            Assert.AreEqual(shippingGotten.TransportCompany, shippingAdd.TransportCompany);

        }

        [Test]
        public void Read_Test()
        {
            ShippingRepository shippingRepository = new ShippingRepository(dbContext, exceptionController);

            Shipping shippingGotten = shippingRepository.Read(3);

            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            Assert.AreEqual(shippingGotten.DepartureDate, dateTimeDeparture);
            Assert.AreEqual(shippingGotten.PackingTime, dateTimePacking);

        }

        [Test]
        public void Update_Test()
        {
            ShippingRepository shippingRepository = new ShippingRepository(dbContext, exceptionController);
            bool correct;
            Shipping shippingGotten = shippingRepository.Read(2);

            DateTime DepartureDateChange = new DateTime(2019, 12, 05, 9, 45, 00);
            DateTime PackingTimeChange = new DateTime(2019, 12, 05, 9, 00, 00);

            shippingGotten.DepartureDate = DepartureDateChange;
            shippingGotten.PackingTime = PackingTimeChange;

            correct = shippingRepository.Update(shippingGotten);

            Shipping shippingCompare = shippingRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(shippingCompare.DepartureDate, shippingGotten.DepartureDate);
            Assert.AreEqual(shippingCompare.PackingTime, shippingGotten.PackingTime);

        }

        [Test]
        public void Delete_Test()
        {
            ShippingRepository shippingRepository = new ShippingRepository(dbContext, exceptionController);
            bool correct;
            Shipping shippingGotten = shippingRepository.Read(1);

            correct = shippingRepository.Delete(shippingGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
