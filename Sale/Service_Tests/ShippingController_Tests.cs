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

    class ShippingController_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            ClientController clientController = new ClientController();
            clientController.InsertClient(new ClientSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            ProductTypeController productTypeController = new ProductTypeController();
            productTypeController.InsertProductType(new ProductTypeSpecific("Ruedas"));
            ProductController productController = new ProductController();
            productController.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            PaymentMethodController paymentMethodController = new PaymentMethodController();
            paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            BillController billController = new BillController();
            billController.InsertBill(new BillSpecific(dateTime, 1));
            SaleController saleController = new SaleController();
            saleController.InsertSale(new SaleSpecific(5, 1, 1, 1));
            TransportCompanyController transportCompanyController = new TransportCompanyController();
            transportCompanyController.InsertTransportCompany(new TransportCompanySpecific("Envi", "911"));
            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            ShippingController shippingController = new ShippingController();

            shippingController.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));
            shippingController.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));
            shippingController.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));

        }

        [Test]
        public void InsertShipping_Test()
        {
            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);
            ShippingController shippingController = new ShippingController();

            String message = shippingController.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));

            Shipping shippingGotten = shippingController.GetShipping(4);

            Assert.AreEqual(message, "Shipping introduced satisfactorily.");
            Assert.AreEqual(shippingGotten.DepartureDate, dateTimeDeparture);
            Assert.AreEqual(shippingGotten.PackingTime, dateTimePacking);

        }

        [Test]
        public void GetShipping_Test()
        {
            ShippingController shippingController = new ShippingController();

            Shipping shippingGotten = shippingController.GetShipping(3);

            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            Assert.AreEqual(shippingGotten.DepartureDate, dateTimeDeparture);
            Assert.AreEqual(shippingGotten.PackingTime, dateTimePacking);

        }

        [Test]
        public void UpdateShipping_Test()
        {
            ShippingController shippingController = new ShippingController();

            DateTime DepartureDateChange = new DateTime(2019, 12, 05, 9, 45, 00);
            DateTime PackingTimeChange = new DateTime(2019, 12, 05, 9, 00, 00);
            ShippingSpecific change = new ShippingSpecific();
            change.ShippingId = 2;
            change.DepartureDate = DepartureDateChange;
            change.PackingTime = PackingTimeChange;

            String message = shippingController.UpdateShipping(change);

            Shipping shippingCompare = shippingController.GetShipping(2);

            Assert.AreEqual(message, "Shipping updated satisfactorily.");
            Assert.AreEqual(shippingCompare.DepartureDate, change.DepartureDate);
            Assert.AreEqual(shippingCompare.PackingTime, change.PackingTime);

        }

        [Test]
        public void DeleteShipping_Test()
        {
            ShippingController shippingController = new ShippingController();

            String message = shippingController.DeleteShipping(1);

            Assert.AreEqual(message, "Shipping deleted satisfactorily.");

        }
    }
}
