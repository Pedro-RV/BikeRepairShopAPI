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
    class ProductController_Tests
    {
        [Test]
        public void InsertProduct_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductBussiness>().InsertProduct(A<ProductSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ProductController>();

                string message = mockService.InsertProduct(new ProductSpecific("Ruedas Armilla", 45, 60, 1));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetProduct_Test()
        {
            using (var fake = new AutoFake())
            {
                Product mockProduct = new Product("Ruedas Armilla", 45, 60, new ProductType());

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductBussiness>().ReadProduct(A<int>.Ignored)).Returns(mockProduct);

                var mockService = fake.Resolve<ProductController>();

                Product product = mockService.GetProduct(1);
            }
        }

        [Test]
        public void UpdateProduct_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductBussiness>().UpdateProduct(A<ProductSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ProductController>();

                string message = mockService.UpdateProduct(new ProductSpecific("Ruedas Armilla", 45, 60, 1));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteProduct_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductBussiness>().DeleteProduct(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ProductController>();

                string message = mockService.DeleteProduct(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
