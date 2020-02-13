using Autofac;
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
    class WarehouseController_Tests
    {
        [Test]
        public void AAWarehousesBiggerThanAnExtension_Test()
        {
            using (var fake = new AutoFake())
            {
                List<Warehouse> mockLista = new List<Warehouse>();
                mockLista.Add(new Warehouse()
                {
                    WarehouseAddress = "Calle Ebro",
                    Extension = 120
                });

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseBussiness>().WarehousesBiggerThanAnExtensionList(A<int>.Ignored)).Returns(mockLista);

                var mockService = fake.Resolve<WarehouseController>();

                List<Warehouse> lista = mockService.WarehousesBiggerThanAnExtensionList(1);
            }
        }

        [Test]
        public void InsertWarehouse_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseBussiness>().InsertWarehouse(A<WarehouseSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<WarehouseController>();

                string message = mockService.InsertWarehouse(new WarehouseSpecific("Calle Tajo", 300));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetWarehouse_Test()
        {
            using (var fake = new AutoFake())
            {
                Warehouse mockEmployee = new Warehouse("Calle Ebro", 120);

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseBussiness>().ReadWarehouse(A<int>.Ignored)).Returns(mockEmployee);

                var mockService = fake.Resolve<WarehouseController>();

                Warehouse warehouse = mockService.GetWarehouse(1);
            }

        }

        [Test]
        public void UpdateWarehouse_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseBussiness>().UpdateWarehouse(A<WarehouseSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<WarehouseController>();

                string message = mockService.UpdateWarehouse(new WarehouseSpecific("Calle Tajo", 300));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteWarehouse_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IWarehouseBussiness>().DeleteWarehouse(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<WarehouseController>();

                string message = mockService.DeleteWarehouse(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
