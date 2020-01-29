using NUnit.Framework;
using Sale_Bussiness;
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
        [TestFixtureSetUp]
        public void Init()
        {
            ClientBussiness clientBussiness = new ClientBussiness();
            clientBussiness.InsertClient(new ClientSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();
            productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ruedas"));
            ProductBussiness productBussiness = new ProductBussiness();
            productBussiness.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            PaymentMethodBussiness paymentMethodBussiness = new PaymentMethodBussiness();
            paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            BillBussiness billBussiness = new BillBussiness();
            billBussiness.InsertBill(new BillSpecific(dateTime, 1));
            SaleBussiness saleBussiness = new SaleBussiness();
            saleBussiness.InsertSale(new SaleSpecific(5, 1, 1, 1));
            TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();
            transportCompanyBussiness.InsertTransportCompany(new TransportCompanySpecific("Envi", "911"));
            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            ShippingBussiness shippingBussiness = new ShippingBussiness();

            shippingBussiness.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));
            shippingBussiness.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));
            shippingBussiness.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));

        }

        [Test]
        public void InsertShipping_Test()
        {
            bool correct;
            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);
            ShippingBussiness shippingBussiness = new ShippingBussiness();

            correct = shippingBussiness.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));

            Shipping shippingGotten = shippingBussiness.ReadShipping(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(shippingGotten.DepartureDate, dateTimeDeparture);
            Assert.AreEqual(shippingGotten.PackingTime, dateTimePacking);

        }

        [Test]
        public void ReadShipping_Test()
        {
            ShippingBussiness shippingBussiness = new ShippingBussiness();

            Shipping shippingGotten = shippingBussiness.ReadShipping(3);

            DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
            DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);

            Assert.AreEqual(shippingGotten.DepartureDate, dateTimeDeparture);
            Assert.AreEqual(shippingGotten.PackingTime, dateTimePacking);

        }

        [Test]
        public void UpdateShipping_Test()
        {
            ShippingBussiness shippingBussiness = new ShippingBussiness();
            bool correct;

            DateTime DepartureDateChange = new DateTime(2019, 12, 05, 9, 45, 00);
            DateTime PackingTimeChange = new DateTime(2019, 12, 05, 9, 00, 00);
            ShippingSpecific change = new ShippingSpecific();
            change.ShippingId = 2;
            change.DepartureDate = DepartureDateChange;
            change.PackingTime = PackingTimeChange;

            correct = shippingBussiness.UpdateShipping(change);

            Shipping shippingCompare = shippingBussiness.ReadShipping(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(shippingCompare.DepartureDate, change.DepartureDate);
            Assert.AreEqual(shippingCompare.PackingTime, change.PackingTime);

        }

        [Test]
        public void DeleteShipping_Test()
        {
            ShippingBussiness shippingBussiness = new ShippingBussiness();
            bool correct;

            correct = shippingBussiness.DeleteShipping(1);

            Assert.AreEqual(true, correct);

        }
    }
}
