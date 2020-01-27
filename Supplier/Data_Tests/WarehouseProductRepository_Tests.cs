using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    class WarehouseProductRepository_Tests
    {
        private SupplierContext dbContext;
        private ExceptionController exceptionController;

        public WarehouseProductRepository_Tests()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            Warehouse warehouse = new Warehouse("Calle Ebro", 120);
            ProductState productStateOne = new ProductState("No disponible");
            ProductState productStateTwo = new ProductState("Disponible");
            ProductState productStateThree = new ProductState("Sin existencias");
            Product product = new Product("Pelota", 20, 5, true);

            WarehouseProduct WarehouseProductOne = new WarehouseProduct(product, warehouse, productStateOne);
            WarehouseProduct WarehouseProductTwo = new WarehouseProduct(product, warehouse, productStateTwo);
            WarehouseProduct WarehouseProductThree = new WarehouseProduct(product, warehouse, productStateThree);

            WarehouseProductRepository WarehouseProductRepository = new WarehouseProductRepository(dbContext, exceptionController);

            WarehouseProductRepository.Insert(WarehouseProductOne);
            WarehouseProductRepository.Insert(WarehouseProductTwo);
            WarehouseProductRepository.Insert(WarehouseProductThree);
        }

        [Test]
        public void Insert_Test()
        {
            Warehouse warehouse = new Warehouse("Calle Tajo", 300);
            ProductState productState = new ProductState("No disponible");
            Product product = new Product("Teclado", 60, 20, true);
            WarehouseProduct WarehouseProductAdd = new WarehouseProduct(product, warehouse, productState);

            bool correct;
            WarehouseProductRepository WarehouseProductRepository = new WarehouseProductRepository(dbContext, exceptionController);

            correct = WarehouseProductRepository.Insert(WarehouseProductAdd);

            WarehouseProduct WarehouseProductGotten = WarehouseProductRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(WarehouseProductGotten.Warehouse, WarehouseProductAdd.Warehouse);
            Assert.AreEqual(WarehouseProductGotten.ProductState, WarehouseProductAdd.ProductState);
            Assert.AreEqual(WarehouseProductGotten.Product, WarehouseProductAdd.Product);

        }

        [Test]
        public void Read_Test()
        {
            WarehouseProductRepository WarehouseProductRepository = new WarehouseProductRepository(dbContext, exceptionController);

            WarehouseProduct WarehouseProductGotten = WarehouseProductRepository.Read(3);

            Assert.AreEqual(WarehouseProductGotten.ProductState.ProductStateDescription, "Sin existencias");

        }

        [Test]
        public void Update_Test()
        {
            WarehouseProductRepository WarehouseProductRepository = new WarehouseProductRepository(dbContext, exceptionController);
            bool correct;
            WarehouseProduct WarehouseProductGotten = WarehouseProductRepository.Read(2);

            WarehouseProductGotten.Product.ProductDescription = "Caja";

            correct = WarehouseProductRepository.Update(WarehouseProductGotten);

            WarehouseProduct WarehouseProductCompare = WarehouseProductRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(WarehouseProductCompare.Product, WarehouseProductGotten.Product);

        }

        [Test]
        public void Delete_Test()
        {
            WarehouseProductRepository WarehouseProductRepository = new WarehouseProductRepository(dbContext, exceptionController);
            bool correct;
            WarehouseProduct WarehouseProductGotten = WarehouseProductRepository.Read(1);

            correct = WarehouseProductRepository.Delete(WarehouseProductGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
