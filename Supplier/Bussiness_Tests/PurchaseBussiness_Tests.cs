using Autofac;
using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
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
        private IPurchaseBussiness purchaseBussiness;
        private IWarehouseBussiness warehouseBussiness;
        private IProductStateBussiness productStateBussiness;
        private IProductBussiness productBussiness;
        private IProductTypeBussiness productTypeBussiness;
        private IEmployeeBussiness employeeBussiness;
        private IWarehouseAdminBussiness warehouseAdminBussiness;
        private ISupplyCompanyBussiness supplyCompanyBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.purchaseBussiness = scope.Resolve<IPurchaseBussiness>();
            this.warehouseBussiness = scope.Resolve<IWarehouseBussiness>();
            this.productStateBussiness = scope.Resolve<IProductStateBussiness>();
            this.productBussiness = scope.Resolve<IProductBussiness>();
            this.productTypeBussiness = scope.Resolve<IProductTypeBussiness>();
            this.employeeBussiness = scope.Resolve<IEmployeeBussiness>();
            this.warehouseAdminBussiness = scope.Resolve<IWarehouseAdminBussiness>();
            this.supplyCompanyBussiness = scope.Resolve<ISupplyCompanyBussiness>();

            this.employeeBussiness.InsertEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            this.warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));
            this.warehouseAdminBussiness.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));
            this.productStateBussiness.InsertProductState(new ProductStateSpecific("No disponible"));
            this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ruedas"));
            this.productBussiness.InsertProduct(new ProductSpecific("Pelota", 20, 5, true, 1));
            this.supplyCompanyBussiness.InsertSupplyCompany(new SupplyCompanySpecific("Ruedas Hermanos Carrasco", "123"));
            DateTime dateTime2 = new DateTime(2019, 05, 17, 13, 05, 00);

            this.purchaseBussiness.InsertPurchase(new PurchaseSpecific(dateTime2, 2, 30, 1, 1));
            this.purchaseBussiness.InsertPurchase(new PurchaseSpecific(dateTime2, 1, 10, 1, 1));
            this.purchaseBussiness.InsertPurchase(new PurchaseSpecific(dateTime2, 5, 120, 1, 1));
            this.purchaseBussiness.InsertPurchase(new PurchaseSpecific(dateTime2, 3, 80, 1, 1));

        }

        [Test]
        public void AAPurchasesBiggerThanAPrizeList_Test()
        {
            List<Purchase> currentPurchase = this.purchaseBussiness.PurchasesBiggerThanAPrizeList(100);

            Assert.AreEqual(currentPurchase[0].Prize, 120);

        }

        [Test]
        public void InsertPurchase_Test()
        {
            bool correct;
            DateTime dateTime = new DateTime(2019, 05, 17, 13, 05, 00);

            correct = this.purchaseBussiness.InsertPurchase(new PurchaseSpecific(dateTime, 10, 500, 1, 1));

            Purchase purchaseGotten = this.purchaseBussiness.ReadPurchase(5);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(purchaseGotten.PurchaseDate, dateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 10);
            Assert.AreEqual(purchaseGotten.Prize, 500);

        }

        [Test]
        public void ReadPurchase_Test()
        {
            Purchase purchaseGotten = this.purchaseBussiness.ReadPurchase(1);

            DateTime seeDateTime = new DateTime(2019, 05, 17, 13, 05, 00);

            Assert.AreEqual(purchaseGotten.PurchaseDate, seeDateTime);
            Assert.AreEqual(purchaseGotten.Cuantity, 2);
            Assert.AreEqual(purchaseGotten.Prize, 30);

        }

        [Test]
        public void UpdatePurchase_Test()
        {
            bool correct;

            PurchaseSpecific change = new PurchaseSpecific();
            change.PurchaseId = 2;
            change.Cuantity = 9;
            change.Prize = 85;

            correct = this.purchaseBussiness.UpdatePurchase(change);

            Purchase purchaseGotten = this.purchaseBussiness.ReadPurchase(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(purchaseGotten.Cuantity, 9);
            Assert.AreEqual(purchaseGotten.Prize, 85);

        }

        [Test]
        public void DeletePurchase_Test()
        {
            bool correct;

            correct = this.purchaseBussiness.DeletePurchase(3);

            Assert.AreEqual(true, correct);

        }

        [Test]
        public void DeletePurchaseAndChangeProduct_Test()
        {
            bool correct;

            correct = this.purchaseBussiness.DeletePurchaseAndChangeProduct(4);

            Assert.AreEqual(true, correct);

        }
    }
}
