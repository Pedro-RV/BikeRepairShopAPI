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
    class SupplyCompanyController_Tests
    {
        [Test]
        public void InsertSupplyCompany_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ISupplyCompanyBussiness>().InsertSupplyCompany(A<SupplyCompanySpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<SupplyCompanyController>();

                string message = mockService.InsertSupplyCompany(new SupplyCompanySpecific("Pesas Cañada", "003"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetSupplyCompany_Test()
        {
            using (var fake = new AutoFake())
            {
                SupplyCompany mockSupplyCompany = new SupplyCompany("Ruedas Hermanos Carrasco", "123");

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ISupplyCompanyBussiness>().ReadSupplyCompany(A<int>.Ignored)).Returns(mockSupplyCompany);

                var mockService = fake.Resolve<SupplyCompanyController>();

                SupplyCompany supplyCompany = mockService.GetSupplyCompany(1);
            }

        }

        [Test]
        public void UpdateSupplyCompany_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ISupplyCompanyBussiness>().UpdateSupplyCompany(A<SupplyCompanySpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<SupplyCompanyController>();

                string message = mockService.UpdateSupplyCompany(new SupplyCompanySpecific("Pesas Cañada", "003"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }

        }

        [Test]
        public void DeleteSupplyCompany_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<ISupplyCompanyBussiness>().DeleteSupplyCompany(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<SupplyCompanyController>();

                string message = mockService.DeleteSupplyCompany(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
