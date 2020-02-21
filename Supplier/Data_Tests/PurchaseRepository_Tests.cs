using Autofac;
using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class PurchaseRepository_Tests
    {
        private IPurchaseRepository purchaseRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.purchaseRepository = scope.Resolve<IPurchaseRepository>();

            ProductType productType = new ProductType("Ruedas");
            Product product = new Product("Pelota", 20, 15, true, productType);
            SupplyCompany supplyCompany = new SupplyCompany("Ruedas Hermanos Carrasco", "123");

            DateTime dateTime2 = new DateTime(2019, 12, 03, 9, 38, 00);

            Purchase purchaseOne = new Purchase(dateTime2, 2, 30, product, supplyCompany);
            Purchase purchaseTwo = new Purchase(dateTime2, 1, 10, product, supplyCompany);
            Purchase purchaseThree = new Purchase(dateTime2, 5, 120, product, supplyCompany);

            this.purchaseRepository.Insert(purchaseOne);
            this.purchaseRepository.Insert(purchaseTwo);
            this.purchaseRepository.Insert(purchaseThree);
        }

        [Test]
        public void Insert_Test()
        {
            ProductType productType = new ProductType("Ruedas");
            Product product = new Product("Pelota", 20, 15, true, productType);
            SupplyCompany supplyCompany = new SupplyCompany("Ruedas Hermanos Carrasco", "123");
            DateTime dateTime2 = new DateTime(2019, 12, 03, 9, 38, 00);
            Purchase purchaseAdd = new Purchase(dateTime2, 10, 500, product, supplyCompany);

            bool correct;

            correct = this.purchaseRepository.Insert(purchaseAdd);

            Purchase purchaseGotten = this.purchaseRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(purchaseGotten.PurchaseDate, purchaseAdd.PurchaseDate);
            Assert.AreEqual(purchaseGotten.Cuantity, purchaseAdd.Cuantity);
            Assert.AreEqual(purchaseGotten.Prize, purchaseAdd.Prize);
            Assert.AreEqual(purchaseGotten.Product, purchaseAdd.Product);
            Assert.AreEqual(purchaseGotten.SupplyCompany, purchaseAdd.SupplyCompany);
        }

        [Test]
        public void Read_Test()
        {
            Purchase purchaseGotten = this.purchaseRepository.Read(3);

            DateTime seeDateTime = new DateTime(2019, 12, 03, 9, 38, 00);

            Assert.AreEqual(purchaseGotten.PurchaseDate, seeDateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 5);
            Assert.AreEqual(purchaseGotten.Prize, 120);

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            Purchase purchaseGotten = this.purchaseRepository.Read(2);

            purchaseGotten.Cuantity = 9;
            purchaseGotten.Prize = 85;

            correct = this.purchaseRepository.Update(purchaseGotten);

            Purchase purchaseCompare = this.purchaseRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(purchaseCompare.Cuantity, purchaseGotten.Cuantity);
            Assert.AreEqual(purchaseCompare.Prize, purchaseGotten.Prize);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            Purchase purchaseGotten = this.purchaseRepository.Read(1);

            correct = this.purchaseRepository.Delete(purchaseGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
