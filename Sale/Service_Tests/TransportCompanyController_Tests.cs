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
    class TransportCompanyController_Tests
    {
        [Test]
        public void InsertTransportCompany_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ITransportCompanyBussiness>().InsertTransportCompany(A<TransportCompanySpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<TransportCompanyController>();

                string message = mockService.InsertTransportCompany(new TransportCompanySpecific("ShipEx", "914"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetTransportCompany_Test()
        {
            using (var fake = new AutoFake())
            {
                TransportCompany mockTransportCompany = new TransportCompany("ShipEx", "914");

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ITransportCompanyBussiness>().ReadTransportCompany(A<int>.Ignored)).Returns(mockTransportCompany);

                var mockService = fake.Resolve<TransportCompanyController>();

                TransportCompany transportCompany = mockService.GetTransportCompany(1);
            }
        }

        [Test]
        public void UpdateTransportCompany_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ITransportCompanyBussiness>().UpdateTransportCompany(A<TransportCompanySpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<TransportCompanyController>();

                string message = mockService.UpdateTransportCompany(new TransportCompanySpecific("ShipEx", "914"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteTransportCompany_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ITransportCompanyBussiness>().DeleteTransportCompany(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<TransportCompanyController>();

                string message = mockService.DeleteTransportCompany(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
