using Autofac;
using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using NUnit.Framework;
using Sale_Bussiness.Interfaces;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using Sale_Helper.Authentication;
using Sale_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tests
{
    [TestFixture]

    class ShippingController_Tests
    {     
        [Test]
        public void InsertShipping_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IShippingBussiness>().InsertShipping(A<ShippingSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ShippingController>();

                DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
                DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);
                string message = mockService.InsertShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetShipping_Test()
        {
            using (var fake = new AutoFake())
            {
                DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
                DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);
                Shipping mockShipping = new Shipping(dateTimeDeparture, dateTimePacking, new Sale(), new TransportCompany());

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IShippingBussiness>().ReadShipping(A<int>.Ignored)).Returns(mockShipping);

                var mockService = fake.Resolve<ShippingController>();

                Shipping shipping = mockService.GetShipping(1);
            }
        }

        [Test]
        public void UpdateShipping_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IShippingBussiness>().UpdateShipping(A<ShippingSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ShippingController>();

                DateTime dateTimeDeparture = new DateTime(2019, 12, 04, 9, 38, 00);
                DateTime dateTimePacking = new DateTime(2019, 12, 04, 9, 00, 00);
                string message = mockService.UpdateShipping(new ShippingSpecific(dateTimeDeparture, dateTimePacking, 1, 1));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteShipping_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IShippingBussiness>().DeleteShipping(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ShippingController>();

                string message = mockService.DeleteShipping(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
