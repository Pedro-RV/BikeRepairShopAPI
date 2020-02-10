using Autofac;
using NUnit.Framework;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
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
        private PurchaseController purchaseController;
        private EmployeeController employeeController;
        private WarehouseController warehouseController;
        private WarehouseAdminController warehouseAdminController;
        private ProductStateController productStateController;
        private ProductController productController;
        private SupplyCompanyController supplyCompanyController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.purchaseController = scope.Resolve<PurchaseController>();
            this.employeeController = scope.Resolve<EmployeeController>();
            this.warehouseController = scope.Resolve<WarehouseController>();
            this.warehouseAdminController = scope.Resolve<WarehouseAdminController>();
            this.productStateController = scope.Resolve<ProductStateController>();
            this.productController = scope.Resolve<ProductController>();
            this.supplyCompanyController = scope.Resolve<SupplyCompanyController>();

            this.employeeController.InsertEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            this.warehouseController.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));
            this.warehouseAdminController.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));
            this.productStateController.InsertProductState(new ProductStateSpecific("No disponible"));
            this.productController.InsertProduct(new ProductSpecific("Pelota", 20, 5, true));
            this.supplyCompanyController.InsertSupplyCompany(new SupplyCompanySpecific("Ruedas Hermanos Carrasco", "123"));
            DateTime dateTime2 = new DateTime(2019, 05, 17, 13, 05, 00);

            this.purchaseController.InsertPurchase(new PurchaseSpecific(dateTime2, 2, 30, 1, 1));
            this.purchaseController.InsertPurchase(new PurchaseSpecific(dateTime2, 1, 10, 1, 1));
            this.purchaseController.InsertPurchase(new PurchaseSpecific(dateTime2, 5, 120, 1, 1));
            this.purchaseController.InsertPurchase(new PurchaseSpecific(dateTime2, 3, 80, 1, 1));

        }

        [Test]
        public void AAPurchasesBiggerThanAPrizeList_Test()
        {
            List<Purchase> currentPurchase = this.purchaseController.PurchasesBiggerThanAPrizeList(100);

            Assert.AreEqual(currentPurchase[0].Prize, 120);

        }

        [Test]
        public void InsertPurchase_Test()
        {
            DateTime dateTime = new DateTime(2019, 05, 17, 13, 05, 00);

            String message = this.purchaseController.InsertPurchase(new PurchaseSpecific(dateTime, 10, 500, 1, 1));

            Purchase purchaseGotten = this.purchaseController.GetPurchase(5);

            Assert.AreEqual(message, "Purchase introduced satisfactorily.");
            Assert.AreEqual(purchaseGotten.PurchaseDate, dateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 10);
            Assert.AreEqual(purchaseGotten.Prize, 500);

        }

        [Test]
        public void GetPurchase_Test()
        {
            Purchase purchaseGotten = this.purchaseController.GetPurchase(1);

            DateTime seeDateTime = new DateTime(2019, 05, 17, 13, 05, 00);

            Assert.AreEqual(purchaseGotten.PurchaseDate, seeDateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 2);
            Assert.AreEqual(purchaseGotten.Prize, 30);

        }

        [Test]
        public void UpdatePurchase_Test()
        {
            PurchaseSpecific change = new PurchaseSpecific();
            change.PurchaseId = 2;
            change.Cuantity = 9;
            change.Prize = 85;

            String message = this.purchaseController.UpdatePurchase(change);

            Purchase purchaseGotten = this.purchaseController.GetPurchase(2);

            Assert.AreEqual(message, "Purchase updated satisfactorily.");
            Assert.AreEqual(purchaseGotten.Cuantity, 9);
            Assert.AreEqual(purchaseGotten.Prize, 85);

        }

        [Test]
        public void DeletePurchase_Test()
        {
            String message = this.purchaseController.DeletePurchase(3);

            Assert.AreEqual(message, "Purchase deleted satisfactorily.");

        }

        [Test]
        public void DeletePurchaseAndChangeProduct_Test()
        {
            String message = this.purchaseController.DeletePurchaseAndChangeProduct(4);

            Assert.AreEqual(message, "Purchase deleted and Product changed satisfactorily.");

        }
    }
}
