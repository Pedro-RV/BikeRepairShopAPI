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
    class PaymentMethodController_Tests
    {
        [Test]
        public void InsertPaymentMethod_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPaymentMethodBussiness>().InsertPaymentMethod(A<PaymentMethodSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<PaymentMethodController>();

                string message = mockService.InsertPaymentMethod(new PaymentMethodSpecific("Cheque"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetPaymentMethod_Test()
        {
            using (var fake = new AutoFake())
            {
                PaymentMethod mockPaymentMethod = new PaymentMethod("Cheque");

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPaymentMethodBussiness>().ReadPaymentMethod(A<int>.Ignored)).Returns(mockPaymentMethod);

                var mockService = fake.Resolve<PaymentMethodController>();

                PaymentMethod paymentMethod = mockService.GetPaymentMethod(1);
            }
        }

        [Test]
        public void UpdatePaymentMethod_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPaymentMethodBussiness>().UpdatePaymentMethod(A<PaymentMethodSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<PaymentMethodController>();

                string message = mockService.UpdatePaymentMethod(new PaymentMethodSpecific("Cheque"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeletePaymentMethod_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPaymentMethodBussiness>().DeletePaymentMethod(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<PaymentMethodController>();

                string message = mockService.DeletePaymentMethod(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
