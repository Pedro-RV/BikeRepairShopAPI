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
        [TestFixtureSetUp]
        public void Init()
        {
            WarehouseController warehouseController = new WarehouseController();
            warehouseController.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));
            ProductStateController productStateController = new ProductStateController();
            productStateController.InsertProductState(new ProductStateSpecific("No disponible"));
            productStateController.InsertProductState(new ProductStateSpecific("Disponible"));
            productStateController.InsertProductState(new ProductStateSpecific("Sin existencias"));
            productStateController.InsertProductState(new ProductStateSpecific("Suspendido"));
            ProductController productController = new ProductController();
            productController.InsertProduct(new ProductSpecific("Pelota", 20, 5, true));

            WarehouseProductController WarehouseProductController = new WarehouseProductController();

            WarehouseProductController.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 1));
            WarehouseProductController.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 2));
            WarehouseProductController.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 3));

        }

        [Test]
        public void InsertWarehouseProduct_Test()
        {
            WarehouseProductController WarehouseProductController = new WarehouseProductController();
            ProductStateController productStateController = new ProductStateController();

            String message = WarehouseProductController.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 4));

            WarehouseProduct WarehouseProductGotten = WarehouseProductController.GetWarehouseProduct(4);
            ProductState checkProductState = productStateController.GetProductState(4);

            Assert.AreEqual(message, "WarehouseProduct introduced satisfactorily.");
            Assert.AreEqual(WarehouseProductGotten.ProductState, checkProductState);

        }

        [Test]
        public void GetWarehouseProduct_Test()
        {
            WarehouseProductController WarehouseProductController = new WarehouseProductController();
            ProductStateController productStateController = new ProductStateController();

            WarehouseProduct WarehouseProductGotten = WarehouseProductController.GetWarehouseProduct(1);
            ProductState checkProductState = productStateController.GetProductState(1);

            Assert.AreEqual(WarehouseProductGotten.ProductState, checkProductState);

        }

        [Test]
        public void UpdateWarehouseProduct_Test()
        {
            WarehouseProductController WarehouseProductController = new WarehouseProductController();
            ProductStateController productStateController = new ProductStateController();

            WarehouseProductSpecific change = new WarehouseProductSpecific();
            change.WarehouseProductId = 2;
            change.ProductStateId = 1;

            String message = WarehouseProductController.UpdateWarehouseProduct(change);

            WarehouseProduct WarehouseProductGotten = WarehouseProductController.GetWarehouseProduct(2);
            ProductState checkProductState = productStateController.GetProductState(1);

            Assert.AreEqual(message, "WarehouseProduct updated satisfactorily.");
            Assert.AreEqual(WarehouseProductGotten.ProductState, checkProductState);

        }

        [Test]
        public void DeleteWarehouseProduct_Test()
        {
            WarehouseProductController WarehouseProductController = new WarehouseProductController();

            String message = WarehouseProductController.DeleteWarehouseProduct(3);

            Assert.AreEqual(message, "WarehouseProduct deleted satisfactorily.");

        }
    }
}
