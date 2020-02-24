using Autofac;
using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using NUnit.Framework;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using Supplier_Helper.Authentication;
using Supplier_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tests
{
    [TestFixture]
    class ProductStateController_Tests
    {
        [Test]
        public void InsertProductState_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductStateBussiness>().InsertProductState(A<ProductStateSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ProductStateController>();

                string message = mockService.InsertProductState(new ProductStateSpecific("No disponible"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetProductState_Test()
        {
            using (var fake = new AutoFake())
            {
                ProductState mockProductState = new ProductState("No disponible");

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductStateBussiness>().ReadProductState(A<int>.Ignored)).Returns(mockProductState);

                var mockService = fake.Resolve<ProductStateController>();

                ProductState productState = mockService.GetProductState(1);
            }
        }

        [Test]
        public void UpdateProductState_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductStateBussiness>().UpdateProductState(A<ProductStateSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ProductStateController>();

                string message = mockService.UpdateProductState(new ProductStateSpecific("No Disponible"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteProductState_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductStateBussiness>().DeleteProductState(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ProductStateController>();

                string message = mockService.DeleteProductState(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
