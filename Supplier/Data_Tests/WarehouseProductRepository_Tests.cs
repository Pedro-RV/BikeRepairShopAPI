using Autofac;
using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class WarehouseProductRepository_Tests
    {
        private IWarehouseProductRepository warehouseProductRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.warehouseProductRepository = scope.Resolve<IWarehouseProductRepository>();

            Warehouse warehouse = new Warehouse("Calle Ebro", 120);
            ProductState productStateOne = new ProductState("No disponible");
            ProductState productStateTwo = new ProductState("Disponible");
            ProductState productStateThree = new ProductState("Sin existencias");
            ProductType productType = new ProductType("Ruedas");
            Product product = new Product("Pelota", 20, 5, true, productType);

            WarehouseProduct warehouseProductOne = new WarehouseProduct(product, warehouse, productStateOne);
            WarehouseProduct warehouseProductTwo = new WarehouseProduct(product, warehouse, productStateTwo);
            WarehouseProduct warehouseProductThree = new WarehouseProduct(product, warehouse, productStateThree);

            this.warehouseProductRepository.Insert(warehouseProductOne);
            this.warehouseProductRepository.Insert(warehouseProductTwo);
            this.warehouseProductRepository.Insert(warehouseProductThree);
        }

        [Test]
        public void Insert_Test()
        {
            Warehouse warehouse = new Warehouse("Calle Tajo", 300);
            ProductState productState = new ProductState("No disponible");
            ProductType productType = new ProductType("Ruedas");
            Product product = new Product("Teclado", 60, 20, true, productType);
            WarehouseProduct warehouseProductAdd = new WarehouseProduct(product, warehouse, productState);

            bool correct;

            correct = this.warehouseProductRepository.Insert(warehouseProductAdd);

            WarehouseProduct warehouseProductGotten = this.warehouseProductRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseProductGotten.Warehouse, warehouseProductAdd.Warehouse);
            Assert.AreEqual(warehouseProductGotten.ProductState, warehouseProductAdd.ProductState);
            Assert.AreEqual(warehouseProductGotten.Product, warehouseProductAdd.Product);

        }

        [Test]
        public void Read_Test()
        {
            WarehouseProduct warehouseProductGotten = this.warehouseProductRepository.Read(3);

            Assert.AreEqual(warehouseProductGotten.ProductState.ProductStateDescription, "Sin existencias");

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            WarehouseProduct warehouseProductGotten = this.warehouseProductRepository.Read(2);

            warehouseProductGotten.Product.ProductDescription = "Caja";

            correct = this.warehouseProductRepository.Update(warehouseProductGotten);

            WarehouseProduct warehouseProductCompare = this.warehouseProductRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseProductCompare.Product, warehouseProductGotten.Product);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            WarehouseProduct warehouseProductGotten = this.warehouseProductRepository.Read(1);

            correct = this.warehouseProductRepository.Delete(warehouseProductGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
