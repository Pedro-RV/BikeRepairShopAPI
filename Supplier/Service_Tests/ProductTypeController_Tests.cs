using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using NUnit.Framework;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
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
    class ProductTypeController_Tests
    {
        [Test]
        public void InsertProductType_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductTypeBussiness>().InsertProductType(A<ProductTypeSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ProductTypeController>();

                string message = mockService.InsertProductType(new ProductTypeSpecific("Llantas"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetProductType_Test()
        {
            using (var fake = new AutoFake())
            {
                ProductType mockProductType = new ProductType("Llantas");

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductTypeBussiness>().ReadProductType(A<int>.Ignored)).Returns(mockProductType);

                var mockService = fake.Resolve<ProductTypeController>();

                ProductType productType = mockService.GetProductType(1);
            }
        }

        [Test]
        public void UpdateProductType_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductTypeBussiness>().UpdateProductType(A<ProductTypeSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ProductTypeController>();

                string message = mockService.UpdateProductType(new ProductTypeSpecific("Llantas"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteProductType_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IProductTypeBussiness>().DeleteProductType(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<ProductTypeController>();

                string message = mockService.DeleteProductType(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
