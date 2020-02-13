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
    class PurchaseController_Tests
    {
        [Test]
        public void AAPurchasesBiggerThanAPrizeList_Test()
        {
            using (var fake = new AutoFake())
            {
                DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);

                List<Purchase> mockLista = new List<Purchase>();
                mockLista.Add(new Purchase()
                {
                    PurchaseDate = dateTime,
                    Cuantity = 4,
                    Prize = 30
                });

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPurchaseBussiness>().PurchasesBiggerThanAPrizeList(A<int>.Ignored)).Returns(mockLista);

                var mockService = fake.Resolve<PurchaseController>();

                List<Purchase> lista = mockService.PurchasesBiggerThanAPrizeList(1);
            }
        }

        [Test]
        public void AAPurchaseDataList_Test()
        {
            using (var fake = new AutoFake())
            {
                DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);

                List<PurchaseData> mockLista = new List<PurchaseData>();
                mockLista.Add(new PurchaseData()
                {
                    ProductDescription = "Tornillo 20mm",
                    PurchaseDate = dateTime,
                    Cuantity = 4,
                    Prize = 30
                });

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPurchaseBussiness>().PurchaseDataList()).Returns(mockLista);

                var mockService = fake.Resolve<PurchaseController>();

                List<PurchaseData> lista = mockService.PurchaseDataList();
            }
        }

        [Test]
        public void InsertPurchase_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPurchaseBussiness>().InsertPurchase(A<PurchaseSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<PurchaseController>();

                DateTime dateTime = new DateTime(2019, 05, 17, 13, 05, 00);
                string message = mockService.InsertPurchase(new PurchaseSpecific(dateTime, 10, 500, 1, 1));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetPurchase_Test()
        {
            using (var fake = new AutoFake())
            {
                DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
                Purchase mockPurchase = new Purchase(dateTime, 2, 30, new Product(), new SupplyCompany());

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPurchaseBussiness>().ReadPurchase(A<int>.Ignored)).Returns(mockPurchase);

                var mockService = fake.Resolve<PurchaseController>();

                Purchase purchase = mockService.GetPurchase(1);
            }
        }

        [Test]
        public void UpdatePurchase_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPurchaseBussiness>().UpdatePurchase(A<PurchaseSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<PurchaseController>();

                DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
                string message = mockService.UpdatePurchase(new PurchaseSpecific(dateTime, 10, 500, 1, 1));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }

        }

        [Test]
        public void DeletePurchase_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPurchaseBussiness>().DeletePurchase(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<PurchaseController>();

                string message = mockService.DeletePurchase(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeletePurchaseAndChangeProduct_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IPurchaseBussiness>().DeletePurchaseAndChangeProduct(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<PurchaseController>();

                string message = mockService.DeletePurchaseAndChangeProduct(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
