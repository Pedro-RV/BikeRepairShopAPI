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
    class WarehouseAdminController_Tests
    {
        [Test]
        public void InsertWarehouseAdmin_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseAdminBussiness>().InsertWarehouseAdmin(A<WarehouseAdminSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<WarehouseAdminController>();

                DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
                string message = mockService.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetWarehouseAdmin_Test()
        {
            using (var fake = new AutoFake())
            {
                DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
                WarehouseAdmin mockWarehouseAdmin = new WarehouseAdmin(dateTime, new Employee(), new Warehouse());

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseAdminBussiness>().ReadWarehouseAdmin(A<int>.Ignored)).Returns(mockWarehouseAdmin);

                var mockService = fake.Resolve<WarehouseAdminController>();

                WarehouseAdmin warehouseAdmin = mockService.GetWarehouseAdmin(1);
            }
        }

        [Test]
        public void UpdateWarehouseAdmin_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseAdminBussiness>().UpdateWarehouseAdmin(A<WarehouseAdminSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<WarehouseAdminController>();

                DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
                string message = mockService.UpdateWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteWarehouseAdmin_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseAdminBussiness>().DeleteWarehouseAdmin(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<WarehouseAdminController>();

                string message = mockService.DeleteWarehouseAdmin(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
