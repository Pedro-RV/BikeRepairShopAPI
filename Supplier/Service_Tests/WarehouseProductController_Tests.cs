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
    class WarehouseProductController_Tests
    {
        [Test]
        public void InsertWarehouseProduct_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseProductBussiness>().InsertWarehouseProduct(A<WarehouseProductSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<WarehouseProductController>();

                DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
                string message = mockService.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 4));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetWarehouseProduct_Test()
        {
            using (var fake = new AutoFake())
            {
                WarehouseProduct mockWarehouseProduct = new WarehouseProduct(new Product(), new Warehouse(), new ProductState());

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseProductBussiness>().ReadWarehouseProduct(A<int>.Ignored)).Returns(mockWarehouseProduct);

                var mockService = fake.Resolve<WarehouseProductController>();

                WarehouseProduct warehouseProduct = mockService.GetWarehouseProduct(1);
            }
        }

        [Test]
        public void UpdateWarehouseProduct_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseProductBussiness>().UpdateWarehouseProduct(A<WarehouseProductSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<WarehouseProductController>();

                string message = mockService.UpdateWarehouseProduct(new WarehouseProductSpecific(1, 1, 4));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteWarehouseProduct_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseProductBussiness>().DeleteWarehouseProduct(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<WarehouseProductController>();

                string message = mockService.DeleteWarehouseProduct(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
