using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    class PurchaseRepository_Tests
    {
        private SupplierContext dbContext;
        private ExceptionController exceptionController;

        public PurchaseRepository_Tests()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            Employee employee = new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            Warehouse warehouse = new Warehouse("Calle Ebro", 120);
            WarehouseAdmin warehouseAdmin = new WarehouseAdmin(dateTime, employee, warehouse);
            ProductState productState = new ProductState("No disponible");
            Product product = new Product("Pelota", 20, 15, warehouse, productState);
            SupplyCompany supplyCompany = new SupplyCompany("Ruedas Hermanos Carrasco", "123");

            DateTime dateTime2 = new DateTime(2019, 12, 03, 9, 38, 00);

            Purchase purchaseOne = new Purchase(dateTime2, 2, 30, product, supplyCompany);
            Purchase purchaseTwo = new Purchase(dateTime2, 1, 10, product, supplyCompany);
            Purchase purchaseThree = new Purchase(dateTime2, 5, 120, product, supplyCompany);


            PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

            purchaseRepository.Insert(purchaseOne);
            purchaseRepository.Insert(purchaseTwo);
            purchaseRepository.Insert(purchaseThree);
        }

        [Test]
        public void Insert_Test()
        {
            Employee employee = new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);           
            Warehouse warehouse = new Warehouse("Calle Ebro", 120);
            WarehouseAdmin warehouseAdmin = new WarehouseAdmin(dateTime, employee, warehouse);
            ProductState productState = new ProductState("No disponible");
            Product product = new Product("Pelota", 20, 15, warehouse, productState);
            SupplyCompany supplyCompany = new SupplyCompany("Ruedas Hermanos Carrasco", "123");
            DateTime dateTime2 = new DateTime(2019, 12, 03, 9, 38, 00);
            Purchase purchaseAdd = new Purchase(dateTime2, 10, 500, product, supplyCompany);

            bool correct;
            PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

            correct = purchaseRepository.Insert(purchaseAdd);

            Purchase purchaseGotten = purchaseRepository.Read(4);

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
            PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);

            Purchase purchaseGotten = purchaseRepository.Read(3);

            DateTime seeDateTime = new DateTime(2019, 12, 03, 9, 38, 00);

            Assert.AreEqual(purchaseGotten.PurchaseDate, seeDateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 5);
            Assert.AreEqual(purchaseGotten.Prize, 120);

        }

        [Test]
        public void Update_Test()
        {
            PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);
            bool correct;
            Purchase purchaseGotten = purchaseRepository.Read(2);

            purchaseGotten.Cuantity = 9;
            purchaseGotten.Prize = 85;

            correct = purchaseRepository.Update(purchaseGotten);

            Purchase purchaseCompare = purchaseRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(purchaseCompare.Cuantity, purchaseGotten.Cuantity);
            Assert.AreEqual(purchaseCompare.Prize, purchaseGotten.Prize);

        }

        [Test]
        public void Delete_Test()
        {
            PurchaseRepository purchaseRepository = new PurchaseRepository(dbContext, exceptionController);
            bool correct;
            Purchase purchaseGotten = purchaseRepository.Read(1);

            correct = purchaseRepository.Delete(purchaseGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
