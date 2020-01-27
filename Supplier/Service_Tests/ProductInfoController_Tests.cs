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
    class ProductInfoController_Tests
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

            ProductInfoController productInfoController = new ProductInfoController();

            productInfoController.InsertProductInfo(new ProductInfoSpecific(1, 1, 1));
            productInfoController.InsertProductInfo(new ProductInfoSpecific(1, 1, 2));
            productInfoController.InsertProductInfo(new ProductInfoSpecific(1, 1, 3));

        }

        [Test]
        public void InsertProductInfo_Test()
        {
            ProductInfoController productInfoController = new ProductInfoController();
            ProductStateController productStateController = new ProductStateController();

            String message = productInfoController.InsertProductInfo(new ProductInfoSpecific(1, 1, 4));

            ProductInfo productInfoGotten = productInfoController.GetProductInfo(4);
            ProductState checkProductState = productStateController.GetProductState(4);

            Assert.AreEqual(message, "ProductInfo introduced satisfactorily.");
            Assert.AreEqual(productInfoGotten.ProductState, checkProductState);

        }

        [Test]
        public void GetProductInfo_Test()
        {
            ProductInfoController productInfoController = new ProductInfoController();
            ProductStateController productStateController = new ProductStateController();

            ProductInfo productInfoGotten = productInfoController.GetProductInfo(1);
            ProductState checkProductState = productStateController.GetProductState(1);

            Assert.AreEqual(productInfoGotten.ProductState, checkProductState);

        }

        [Test]
        public void UpdateProductInfo_Test()
        {
            ProductInfoController productInfoController = new ProductInfoController();
            ProductStateController productStateController = new ProductStateController();

            ProductInfoSpecific change = new ProductInfoSpecific();
            change.ProductInfoId = 2;
            change.ProductStateId = 1;

            String message = productInfoController.UpdateProductInfo(change);

            ProductInfo productInfoGotten = productInfoController.GetProductInfo(2);
            ProductState checkProductState = productStateController.GetProductState(1);

            Assert.AreEqual(message, "ProductInfo updated satisfactorily.");
            Assert.AreEqual(productInfoGotten.ProductState, checkProductState);

        }

        [Test]
        public void DeleteProductInfo_Test()
        {
            ProductInfoController productInfoController = new ProductInfoController();

            String message = productInfoController.DeleteProductInfo(3);

            Assert.AreEqual(message, "ProductInfo deleted satisfactorily.");

        }
    }
}
