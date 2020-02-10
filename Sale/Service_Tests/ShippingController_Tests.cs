using Autofac;
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
        private ShippingController shippingController;
        private SaleController saleController;
        private ProductController productController;
        private ProductTypeController productTypeController;
        private BillController billController;
        private PaymentMethodController paymentMethodController;
        private ClientController clientController;
        private TransportCompanyController transportCompanyController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.shippingController = scope.Resolve<ShippingController>();
            this.saleController = scope.Resolve<SaleController>();
            this.billController = scope.Resolve<BillController>();
            this.paymentMethodController = scope.Resolve<PaymentMethodController>();
            this.productController = scope.Resolve<ProductController>();
            this.productTypeController = scope.Resolve<ProductTypeController>();
            this.clientController = scope.Resolve<ClientController>();
            this.transportCompanyController = scope.Resolve<TransportCompanyController>();

            this.clientController.InsertClient(new ClientSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            this.productTypeController.InsertProductType(new ProductTypeSpecific("Ruedas"));
            this.productController.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            this.paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            this.billController.InsertBill(new BillSpecific(dateTime, 1));
            this.saleController.InsertSale(new SaleSpecific(5, 1, 1, 1));
            this.transportCompanyController.InsertTransportCompany(new TransportCompanySpecific("Envi", "911"));
            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            this.shippingController.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));
            this.shippingController.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));
            this.shippingController.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));

        }

        [Test]
        public void InsertShipping_Test()
        {
            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            string message = this.shippingController.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));

            Shipping shippingGotten = this.shippingController.GetShipping(4);

            Assert.AreEqual(message, "Shipping introduced satisfactorily.");
            Assert.AreEqual(shippingGotten.DepartureDate, dateTimeDeparture);
            Assert.AreEqual(shippingGotten.PackingTime, dateTimePacking);

        }

        [Test]
        public void GetShipping_Test()
        {
            Shipping shippingGotten = this.shippingController.GetShipping(1);

            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            Assert.AreEqual(shippingGotten.DepartureDate, dateTimeDeparture);
            Assert.AreEqual(shippingGotten.PackingTime, dateTimePacking);

        }

        [Test]
        public void UpdateShipping_Test()
        {
            DateTime DepartureDateChange = new DateTime(2019, 12, 05, 9, 45, 00);
            DateTime PackingTimeChange = new DateTime(2019, 12, 05, 9, 00, 00);
            ShippingSpecific change = new ShippingSpecific();
            change.ShippingId = 2;
            change.DepartureDate = DepartureDateChange;
            change.PackingTime = PackingTimeChange;

            string message = this.shippingController.UpdateShipping(change);

            Shipping shippingCompare = this.shippingController.GetShipping(2);

            Assert.AreEqual(message, "Shipping updated satisfactorily.");
            Assert.AreEqual(shippingCompare.DepartureDate, change.DepartureDate);
            Assert.AreEqual(shippingCompare.PackingTime, change.PackingTime);

        }

        [Test]
        public void DeleteShipping_Test()
        {
            string message = this.shippingController.DeleteShipping(3);

            Assert.AreEqual(message, "Shipping deleted satisfactorily.");

        }
    }
}
