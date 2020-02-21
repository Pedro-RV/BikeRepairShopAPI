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
    class SaleController_Tests
    {     
        [Test]
        public void InsertSale_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ISaleBussiness>().InsertSale(A<SaleSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<SaleController>();

                string message = mockService.InsertSale(new SaleSpecific(50, 1, 1, 1));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetSale_Test()
        {
            using (var fake = new AutoFake())
            {
                Sale mockSale = new Sale(50, 1, new Client(), new Bill());

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ISaleBussiness>().ReadSale(A<int>.Ignored)).Returns(mockSale);

                var mockService = fake.Resolve<SaleController>();

                Sale sale = mockService.GetSale(1);
            }
        }

        [Test]
        public void UpdateSale_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ISaleBussiness>().UpdateSale(A<SaleSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<SaleController>();

                string message = mockService.UpdateSale(new SaleSpecific(50, 1, 1, 1));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteSale_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ISaleBussiness>().DeleteSale(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<SaleController>();

                string message = mockService.DeleteSale(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
