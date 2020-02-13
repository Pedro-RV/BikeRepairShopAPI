using Autofac;
using NUnit.Framework;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using Supplier_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Autofac.Extras.FakeItEasy;
using Supplier_Helper.Authentication;
using System.Net.Http.Headers;
using Supplier_Bussiness.Interfaces;

namespace Service_Tests
{
    [TestFixture]
    class ProductController_Tests
    {
        [Test]
        public void AAProductsList_Test()
        {
            using (var fake = new AutoFake())
            {
                List<Product> mockLista = new List<Product>();
                mockLista.Add(new Product()
                {
                    ProductDescription = "Cascos MPOW 2005",
                    Prize = 22
                });

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductBussiness>().ProductsList()).Returns(mockLista);

                var mockService = fake.Resolve<ProductController>();

                List<Product> lista = mockService.ProductsList();
            }
        }

        [Test]
        public void InsertProduct_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductBussiness>().InsertProduct(A<ProductSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ProductController>();

                string message = mockService.InsertProduct(new ProductSpecific("Teclado", 60, 20, true));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetProduct_Test()
        {
            using (var fake = new AutoFake())
            {
                Product mockProduct = new Product("Pelota", 20, 5, true);

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

                string message = mockService.UpdateProduct(new ProductSpecific("Teclado", 60, 20, true));

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
