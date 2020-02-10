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
    class WarehouseProductController_Tests
    {
        private WarehouseController warehouseController;
        private WarehouseProductController warehouseProductController;
        private ProductStateController productStateController;
        private ProductController productController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.warehouseController = scope.Resolve<WarehouseController>();
            this.warehouseProductController = scope.Resolve<WarehouseProductController>();
            this.productStateController = scope.Resolve<ProductStateController>();
            this.productController = scope.Resolve<ProductController>();

            this.warehouseController.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));
            this.productStateController.InsertProductState(new ProductStateSpecific("No disponible"));
            this.productStateController.InsertProductState(new ProductStateSpecific("Disponible"));
            this.productStateController.InsertProductState(new ProductStateSpecific("Sin existencias"));
            this.productStateController.InsertProductState(new ProductStateSpecific("Suspendido"));
            this.productController.InsertProduct(new ProductSpecific("Pelota", 20, 5, true));

            this.warehouseProductController.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 1));
            this.warehouseProductController.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 2));
            this.warehouseProductController.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 3));

        }

        [Test]
        public void InsertWarehouseProduct_Test()
        {
            string message = this.warehouseProductController.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 4));

            WarehouseProduct warehouseProductGotten = this.warehouseProductController.GetWarehouseProduct(4);
            ProductState checkProductState = this.productStateController.GetProductState(4);
            
            Assert.AreEqual(message, "WarehouseProduct introduced satisfactorily.");
            Assert.AreEqual(warehouseProductGotten.ProductState, checkProductState);

        }

        [Test]
        public void GetWarehouseProduct_Test()
        {
            WarehouseProduct warehouseProductGotten = this.warehouseProductController.GetWarehouseProduct(1);
            ProductState checkProductState = this.productStateController.GetProductState(1);

            Assert.AreEqual(warehouseProductGotten.ProductState, checkProductState);

        }

        [Test]
        public void UpdateWarehouseProduct_Test()
        {
            WarehouseProductSpecific change = new WarehouseProductSpecific();
            change.WarehouseProductId = 2;
            change.ProductStateId = 1;

            string message = this.warehouseProductController.UpdateWarehouseProduct(change);

            WarehouseProduct warehouseProductGotten = this.warehouseProductController.GetWarehouseProduct(2);
            ProductState checkProductState = this.productStateController.GetProductState(1);

            Assert.AreEqual(message, "WarehouseProduct updated satisfactorily.");
            Assert.AreEqual(warehouseProductGotten.ProductState, checkProductState);

        }

        [Test]
        public void DeleteWarehouseProduct_Test()
        {
            string message = this.warehouseProductController.DeleteWarehouseProduct(3);

            Assert.AreEqual(message, "WarehouseProduct deleted satisfactorily.");

        }
    }
}
