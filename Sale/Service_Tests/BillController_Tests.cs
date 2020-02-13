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
    class BillController_Tests
    {
        [Test]
        public void InsertBill_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IBillBussiness>().InsertBill(A<BillSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<BillController>();

                DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
                string message = mockService.InsertBill(new BillSpecific(dateTime, 4));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetBill_Test()
        {
            using (var fake = new AutoFake())
            {
                DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
                Bill mockBill = new Bill(dateTime, new PaymentMethod());

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IBillBussiness>().ReadBill(A<int>.Ignored)).Returns(mockBill);

                var mockService = fake.Resolve<BillController>();

                Bill bill = mockService.GetBill(1);
            }
        }

        [Test]
        public void UpdateBill_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IBillBussiness>().UpdateBill(A<BillSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<BillController>();

                DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
                string message = mockService.UpdateBill(new BillSpecific(dateTime, 4));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteBill_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IBillBussiness>().DeleteBill(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<BillController>();

                string message = mockService.DeleteBill(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
