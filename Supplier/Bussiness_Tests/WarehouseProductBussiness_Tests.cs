using Autofac;
using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
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
    class WarehouseProductBussiness_Tests
    {
        private IWarehouseProductBussiness warehouseProductBussiness;
        private IWarehouseBussiness warehouseBussiness;
        private IProductStateBussiness productStateBussiness;
        private IProductBussiness productBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.warehouseProductBussiness = scope.Resolve<IWarehouseProductBussiness>();
            this.warehouseBussiness = scope.Resolve<IWarehouseBussiness>();
            this.productStateBussiness = scope.Resolve<IProductStateBussiness>();
            this.productBussiness = scope.Resolve<IProductBussiness>();

            this.warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));
            this.productStateBussiness.InsertProductState(new ProductStateSpecific("No disponible"));
            this.productStateBussiness.InsertProductState(new ProductStateSpecific("Disponible"));
            this.productStateBussiness.InsertProductState(new ProductStateSpecific("Sin existencias"));
            this.productStateBussiness.InsertProductState(new ProductStateSpecific("Suspendido"));
            this.productBussiness.InsertProduct(new ProductSpecific("Pelota", 20, 5, true));

            this.warehouseProductBussiness.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 1));
            this.warehouseProductBussiness.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 2));
            this.warehouseProductBussiness.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 3));

        }

        [Test]
        public void InsertWarehouseProduct_Test()
        {
            bool correct;

            correct = this.warehouseProductBussiness.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 4));

            WarehouseProduct warehouseProductGotten = this.warehouseProductBussiness.ReadWarehouseProduct(4);
            ProductState checkProductState = this.productStateBussiness.ReadProductState(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseProductGotten.ProductState, checkProductState);

        }

        [Test]
        public void ReadWarehouseProduct_Test()
        {
            WarehouseProduct warehouseProductGotten = this.warehouseProductBussiness.ReadWarehouseProduct(1);
            ProductState checkProductState = this.productStateBussiness.ReadProductState(1);

            Assert.AreEqual(warehouseProductGotten.ProductState, checkProductState);

        }

        [Test]
        public void UpdateWarehouseProduct_Test()
        {
            bool correct;

            WarehouseProductSpecific change = new WarehouseProductSpecific();
            change.WarehouseProductId = 2;
            change.ProductStateId = 1;

            correct = this.warehouseProductBussiness.UpdateWarehouseProduct(change);

            WarehouseProduct warehouseProductGotten = this.warehouseProductBussiness.ReadWarehouseProduct(2);
            ProductState checkProductState = this.productStateBussiness.ReadProductState(1);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseProductGotten.ProductState, checkProductState);

        }

        [Test]
        public void DeleteWarehouseProduct_Test()
        {
            bool correct;

            correct = this.warehouseProductBussiness.DeleteWarehouseProduct(3);

            Assert.AreEqual(true, correct);

        }
    }
}
