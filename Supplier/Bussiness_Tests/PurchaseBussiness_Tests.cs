using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Tests
{
    [TestFixture]
    class PurchaseBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();
            employeeBussiness.InsertEmployee(new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();
            warehouseAdminBussiness.InsertWarehouseAdmin(new WarehouseAdmin(dateTime, employeeBussiness.ReadEmployee(1)));
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();
            warehouseBussiness.InsertWarehouse(new Warehouse("Calle Ebro", 120, warehouseAdminBussiness.ReadWarehouseAdmin(1)));
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();
            productStateBussiness.InsertProductState(new ProductState("No disponible"));
            ProductBussiness productBussiness = new ProductBussiness();
            productBussiness.InsertProduct(new Product("Pelota", 20, 5, warehouseBussiness.ReadWarehouse(1), productStateBussiness.ReadProductState(1)));
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();
            supplyCompanyBussiness.InsertSupplyCompany(new SupplyCompany("Ruedas Hermanos Carrasco", "123"));
            DateTime dateTime2 = new DateTime(2019, 05, 17, 13, 05, 00);

            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            purchaseBussiness.InsertPurchase(new Purchase(dateTime2, 2, 30, productBussiness.ReadProduct(1), supplyCompanyBussiness.ReadSupplyCompany(1)));
            purchaseBussiness.InsertPurchase(new Purchase(dateTime2, 1, 10, productBussiness.ReadProduct(1), supplyCompanyBussiness.ReadSupplyCompany(1)));
            purchaseBussiness.InsertPurchase(new Purchase(dateTime2, 5, 120, productBussiness.ReadProduct(1), supplyCompanyBussiness.ReadSupplyCompany(1)));
            purchaseBussiness.InsertPurchase(new Purchase(dateTime2, 3, 80, productBussiness.ReadProduct(1), supplyCompanyBussiness.ReadSupplyCompany(1)));

        }

        [Test]
        public void AAPurchasesBiggerThanAPrizeList_Test()
        {
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            List<Purchase> currentPurchase = purchaseBussiness.PurchasesBiggerThanAPrizeList(100);

            Assert.AreEqual(currentPurchase[0].Prize, 120);

        }

        [Test]
        public void InsertPurchase_Test()
        {
            bool correct;
            DateTime dateTime = new DateTime(2019, 05, 17, 13, 05, 00);

            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();
            ProductBussiness productBussiness = new ProductBussiness();
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            correct = purchaseBussiness.InsertPurchase(new Purchase(dateTime, 10, 500, productBussiness.ReadProduct(1), supplyCompanyBussiness.ReadSupplyCompany(1)));

            Purchase purchaseGotten = purchaseBussiness.ReadPurchase(5);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(purchaseGotten.PurchaseDate, dateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 10);
            Assert.AreEqual(purchaseGotten.Prize, 500);

        }

        [Test]
        public void InsertPurchaseAndProduct_Test()
        {
            bool correct;
            DateTime dateTime = new DateTime(2019, 05, 17, 13, 05, 00);

            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            correct = purchaseBussiness.InsertPurchaseAndProduct(new Product("Luz led", 0.7, 50, warehouseBussiness.ReadWarehouse(1), productStateBussiness.ReadProductState(1)), new Purchase(dateTime, 100, 50, null, supplyCompanyBussiness.ReadSupplyCompany(1)));

            Purchase purchaseGotten = purchaseBussiness.ReadPurchase(6);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(purchaseGotten.PurchaseDate, dateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 100);
            Assert.AreEqual(purchaseGotten.Prize, 50);

        }

        [Test]
        public void ReadPurchase_Test()
        {
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            Purchase purchaseGotten = purchaseBussiness.ReadPurchase(1);

            DateTime seeDateTime = new DateTime(2019, 05, 17, 13, 05, 00);

            Assert.AreEqual(purchaseGotten.PurchaseDate, seeDateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 2);
            Assert.AreEqual(purchaseGotten.Prize, 30);

        }

        [Test]
        public void UpdatePurchase_Test()
        {
            bool correct;
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            Purchase change = purchaseBussiness.ReadPurchase(2);
            change.Cuantity = 9;
            change.Prize = 85;

            correct = purchaseBussiness.UpdatePurchase(change);

            Purchase purchaseGotten = purchaseBussiness.ReadPurchase(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(purchaseGotten.Cuantity, 9);
            Assert.AreEqual(purchaseGotten.Prize, 85);

        }

        [Test]
        public void DeletePurchase_Test()
        {
            bool correct;
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            correct = purchaseBussiness.DeletePurchase(3);

            Assert.AreEqual(true, correct);

        }

        [Test]
        public void DeletePurchaseAndChangeProduct_Test()
        {
            bool correct;
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            correct = purchaseBussiness.DeletePurchaseAndChangeProduct(4);

            Assert.AreEqual(true, correct);

        }
    }
}
