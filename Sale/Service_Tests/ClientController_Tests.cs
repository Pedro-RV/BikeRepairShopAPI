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
    class ClientController_Tests
    {
        [Test]
        public void InsertClient_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IClientBussiness>().InsertClient(A<ClientSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ClientController>();

                string message = mockService.InsertClient(new ClientSpecific("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }           
        }

        [Test]
        public void GetClient_Test()
        {
            using (var fake = new AutoFake())
            {
                Client mockClient = new Client("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87");

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IClientBussiness>().ReadClient(A<int>.Ignored)).Returns(mockClient);

                var mockService = fake.Resolve<ClientController>();

                Client client = mockService.GetClient(1);
            }
        }

        [Test]
        public void UpdateClient_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IClientBussiness>().UpdateClient(A<ClientSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ClientController>();

                string message = mockService.UpdateClient(new ClientSpecific("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteClient_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IClientBussiness>().DeleteClient(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ClientController>();

                string message = mockService.DeleteClient(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

    }
}
