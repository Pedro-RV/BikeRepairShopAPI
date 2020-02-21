using Autofac;
using NUnit.Framework;
using Sale_Bussiness;
using Sale_Bussiness.Interfaces;
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
    class ShippingBussiness_Tests
    {
        private IShippingBussiness shippingBussiness;
        private ISaleBussiness saleBussiness;
        private IClientBussiness clientBussiness;
        private IPaymentMethodBussiness paymentMethodBussiness;
        private IBillBussiness billBussiness;
        private ITransportCompanyBussiness transportCompanyBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.shippingBussiness = scope.Resolve<IShippingBussiness>();
            this.saleBussiness = scope.Resolve<ISaleBussiness>();
            this.clientBussiness = scope.Resolve<IClientBussiness>();
            this.paymentMethodBussiness = scope.Resolve<IPaymentMethodBussiness>();
            this.billBussiness = scope.Resolve<IBillBussiness>();
            this.transportCompanyBussiness = scope.Resolve<ITransportCompanyBussiness>();

            this.clientBussiness.InsertClient(new ClientSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            this.paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            this.billBussiness.InsertBill(new BillSpecific(dateTime, 1));
            this.saleBussiness.InsertSale(new SaleSpecific(5, 1, 1, 1));
            this.transportCompanyBussiness.InsertTransportCompany(new TransportCompanySpecific("Envi", "911"));
            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            this.shippingBussiness.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));
            this.shippingBussiness.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));
            this.shippingBussiness.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));

        }

        [Test]
        public void InsertShipping_Test()
        {
            bool correct;
            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            correct = this.shippingBussiness.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));

            Shipping shippingGotten = this.shippingBussiness.ReadShipping(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(shippingGotten.DepartureDate, dateTimeDeparture);
            Assert.AreEqual(shippingGotten.PackingTime, dateTimePacking);

        }

        [Test]
        public void ReadShipping_Test()
        {
            Shipping shippingGotten = this.shippingBussiness.ReadShipping(1);

            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            Assert.AreEqual(shippingGotten.DepartureDate, dateTimeDeparture);
            Assert.AreEqual(shippingGotten.PackingTime, dateTimePacking);

        }

        [Test]
        public void UpdateShipping_Test()
        {
            bool correct;

            DateTime DepartureDateChange = new DateTime(2019, 12, 05, 9, 45, 00);
            DateTime PackingTimeChange = new DateTime(2019, 12, 05, 9, 00, 00);
            ShippingSpecific change = new ShippingSpecific();
            change.ShippingId = 2;
            change.DepartureDate = DepartureDateChange;
            change.PackingTime = PackingTimeChange;

            correct = this.shippingBussiness.UpdateShipping(change);

            Shipping shippingCompare = this.shippingBussiness.ReadShipping(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(shippingCompare.DepartureDate, change.DepartureDate);
            Assert.AreEqual(shippingCompare.PackingTime, change.PackingTime);

        }

        [Test]
        public void DeleteShipping_Test()
        {
            bool correct;

            correct = this.shippingBussiness.DeleteShipping(3);

            Assert.AreEqual(true, correct);

        }
    }
}
