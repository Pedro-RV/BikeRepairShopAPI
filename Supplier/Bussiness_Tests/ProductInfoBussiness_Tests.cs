using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Tests
{
    [TestFixture]
    class ProductInfoBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();
            warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();
            productStateBussiness.InsertProductState(new ProductStateSpecific("No disponible"));
            productStateBussiness.InsertProductState(new ProductStateSpecific("Disponible"));
            productStateBussiness.InsertProductState(new ProductStateSpecific("Sin existencias"));
            productStateBussiness.InsertProductState(new ProductStateSpecific("Suspendido"));
            ProductBussiness productBussiness = new ProductBussiness();
            productBussiness.InsertProduct(new ProductSpecific("Pelota", 20, 5, true));

            ProductInfoBussiness productInfoBussiness = new ProductInfoBussiness();

            productInfoBussiness.InsertProductInfo(new ProductInfoSpecific(1, 1, 1));
            productInfoBussiness.InsertProductInfo(new ProductInfoSpecific(1, 1, 2));
            productInfoBussiness.InsertProductInfo(new ProductInfoSpecific(1, 1, 3));

        }

        [Test]
        public void InsertProductInfo_Test()
        {
            bool correct;
            ProductInfoBussiness productInfoBussiness = new ProductInfoBussiness();
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            correct = productInfoBussiness.InsertProductInfo(new ProductInfoSpecific(1, 1, 4));

            ProductInfo productInfoGotten = productInfoBussiness.ReadProductInfo(4);
            ProductState checkProductState = productStateBussiness.ReadProductState(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productInfoGotten.ProductState, checkProductState);

        }

        [Test]
        public void ReadProductInfo_Test()
        {
            ProductInfoBussiness productInfoBussiness = new ProductInfoBussiness();
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            ProductInfo productInfoGotten = productInfoBussiness.ReadProductInfo(1);
            ProductState checkProductState = productStateBussiness.ReadProductState(1);

            Assert.AreEqual(productInfoGotten.ProductState, checkProductState);

        }

        [Test]
        public void UpdateProductInfo_Test()
        {
            bool correct;
            ProductInfoBussiness productInfoBussiness = new ProductInfoBussiness();
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            ProductInfoSpecific change = new ProductInfoSpecific();
            change.ProductInfoId = 2;
            change.ProductStateId = 1;

            correct = productInfoBussiness.UpdateProductInfo(change);

            ProductInfo productInfoGotten = productInfoBussiness.ReadProductInfo(2);
            ProductState checkProductState = productStateBussiness.ReadProductState(1);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productInfoGotten.ProductState, checkProductState);

        }

        [Test]
        public void DeleteProductInfo_Test()
        {
            bool correct;
            ProductInfoBussiness productInfoBussiness = new ProductInfoBussiness();

            correct = productInfoBussiness.DeleteProductInfo(3);

            Assert.AreEqual(true, correct);

        }
    }
}
