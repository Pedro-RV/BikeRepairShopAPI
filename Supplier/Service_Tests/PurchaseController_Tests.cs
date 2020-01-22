using NUnit.Framework;
using Supplier_Entities.EntityModel;
using Supplier_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tests
{
    [TestFixture]
    class PurchaseController_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            EmployeeController employeeController = new EmployeeController();
            employeeController.InsertEmployee(new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            WarehouseAdminController warehouseAdminController = new WarehouseAdminController();
            warehouseAdminController.InsertWarehouseAdmin(new WarehouseAdmin(dateTime, employeeController.GetEmployee(1)));
            WarehouseController warehouseController = new WarehouseController();
            warehouseController.InsertWarehouse(new Warehouse("Calle Ebro", 120, warehouseAdminController.GetWarehouseAdmin(1)));
            ProductStateController productStateController = new ProductStateController();
            productStateController.InsertProductState(new ProductState("No disponible"));
            ProductController productController = new ProductController();
            productController.InsertProduct(new Product("Pelota", 20, 5, warehouseController.GetWarehouse(1), productStateController.GetProductState(1)));
            SupplyCompanyController supplyCompanyController = new SupplyCompanyController();
            supplyCompanyController.InsertSupplyCompany(new SupplyCompany("Ruedas Hermanos Carrasco", "123"));
            DateTime dateTime2 = new DateTime(2019, 05, 17, 13, 05, 00);

            PurchaseController purchaseController = new PurchaseController();

            purchaseController.InsertPurchase(new Purchase(dateTime2, 2, 30, productController.GetProduct(1), supplyCompanyController.GetSupplyCompany(1)));
            purchaseController.InsertPurchase(new Purchase(dateTime2, 1, 10, productController.GetProduct(1), supplyCompanyController.GetSupplyCompany(1)));
            purchaseController.InsertPurchase(new Purchase(dateTime2, 5, 120, productController.GetProduct(1), supplyCompanyController.GetSupplyCompany(1)));
            purchaseController.InsertPurchase(new Purchase(dateTime2, 3, 80, productController.GetProduct(1), supplyCompanyController.GetSupplyCompany(1)));

        }

        [Test]
        public void AAPurchasesBiggerThanAPrizeList_Test()
        {
            PurchaseController purchaseController = new PurchaseController();

            List<Purchase> currentPurchase = purchaseController.PurchasesBiggerThanAPrizeList(100);

            Assert.AreEqual(currentPurchase[0].Prize, 120);

        }

        [Test]
        public void InsertPurchase_Test()
        {
            DateTime dateTime = new DateTime(2019, 05, 17, 13, 05, 00);

            PurchaseController purchaseController = new PurchaseController();
            ProductController productController = new ProductController();
            SupplyCompanyController supplyCompanyController = new SupplyCompanyController();

            String message = purchaseController.InsertPurchase(new Purchase(dateTime, 10, 500, productController.GetProduct(1), supplyCompanyController.GetSupplyCompany(1)));

            Purchase purchaseGotten = purchaseController.GetPurchase(5);

            Assert.AreEqual(message, "Purchase introduced satisfactorily.");
            Assert.AreEqual(purchaseGotten.PurchaseDate, dateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 10);
            Assert.AreEqual(purchaseGotten.Prize, 500);

        }

        [Test]
        public void InsertPurchaseAndProduct_Test()
        {
            DateTime dateTime = new DateTime(2019, 05, 17, 13, 05, 00);

            PurchaseController purchaseController = new PurchaseController();
            WarehouseController warehouseController = new WarehouseController();
            ProductStateController productStateController = new ProductStateController();
            SupplyCompanyController supplyCompanyController = new SupplyCompanyController();

            String message = purchaseController.InsertPurchaseAndProduct(new Product("Luz led", 0.7, 50, warehouseController.GetWarehouse(1), productStateController.GetProductState(1)), new Purchase(dateTime, 100, 50, null, supplyCompanyController.GetSupplyCompany(1)));

            Purchase purchaseGotten = purchaseController.GetPurchase(6);

            Assert.AreEqual(message, "Product and Purchase introduced satisfactorily.");
            Assert.AreEqual(purchaseGotten.PurchaseDate, dateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 100);
            Assert.AreEqual(purchaseGotten.Prize, 50);

        }

        [Test]
        public void GetPurchase_Test()
        {
            PurchaseController purchaseController = new PurchaseController();

            Purchase purchaseGotten = purchaseController.GetPurchase(1);

            DateTime seeDateTime = new DateTime(2019, 05, 17, 13, 05, 00);

            Assert.AreEqual(purchaseGotten.PurchaseDate, seeDateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 2);
            Assert.AreEqual(purchaseGotten.Prize, 30);

        }

        [Test]
        public void UpdatePurchase_Test()
        {
            PurchaseController purchaseController = new PurchaseController();

            Purchase change = purchaseController.GetPurchase(2);
            change.Cuantity = 9;
            change.Prize = 85;

            String message = purchaseController.UpdatePurchase(change);

            Purchase purchaseGotten = purchaseController.GetPurchase(2);

            Assert.AreEqual(message, "Purchase updated satisfactorily.");
            Assert.AreEqual(purchaseGotten.Cuantity, 9);
            Assert.AreEqual(purchaseGotten.Prize, 85);

        }

        [Test]
        public void DeletePurchase_Test()
        {
            PurchaseController purchaseController = new PurchaseController();

            String message = purchaseController.DeletePurchase(3);

            Assert.AreEqual(message, "Purchase deleted satisfactorily.");

        }

        [Test]
        public void DeletePurchaseAndChangeProduct_Test()
        {
            PurchaseController purchaseController = new PurchaseController();

            String message = purchaseController.DeletePurchaseAndChangeProduct(4);

            Assert.AreEqual(message, "Purchase deleted and Product changed satisfactorily.");

        }
    }
}
