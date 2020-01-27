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
    class ProductInfoRepository_Tests
    {
        private SupplierContext dbContext;
        private ExceptionController exceptionController;

        public ProductInfoRepository_Tests()
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

            ProductInfo productInfoOne = new ProductInfo(product, warehouse, productStateOne);
            ProductInfo productInfoTwo = new ProductInfo(product, warehouse, productStateTwo);
            ProductInfo productInfoThree = new ProductInfo(product, warehouse, productStateThree);

            ProductInfoRepository productInfoRepository = new ProductInfoRepository(dbContext, exceptionController);

            productInfoRepository.Insert(productInfoOne);
            productInfoRepository.Insert(productInfoTwo);
            productInfoRepository.Insert(productInfoThree);
        }

        [Test]
        public void Insert_Test()
        {
            Warehouse warehouse = new Warehouse("Calle Tajo", 300);
            ProductState productState = new ProductState("No disponible");
            Product product = new Product("Teclado", 60, 20, true);
            ProductInfo productInfoAdd = new ProductInfo(product, warehouse, productState);

            bool correct;
            ProductInfoRepository productInfoRepository = new ProductInfoRepository(dbContext, exceptionController);

            correct = productInfoRepository.Insert(productInfoAdd);

            ProductInfo productInfoGotten = productInfoRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productInfoGotten.Warehouse, productInfoAdd.Warehouse);
            Assert.AreEqual(productInfoGotten.ProductState, productInfoAdd.ProductState);
            Assert.AreEqual(productInfoGotten.Product, productInfoAdd.Product);

        }

        [Test]
        public void Read_Test()
        {
            ProductInfoRepository productInfoRepository = new ProductInfoRepository(dbContext, exceptionController);

            ProductInfo productInfoGotten = productInfoRepository.Read(3);

            Assert.AreEqual(productInfoGotten.ProductState.ProductStateDescription, "Sin existencias");

        }

        [Test]
        public void Update_Test()
        {
            ProductInfoRepository productInfoRepository = new ProductInfoRepository(dbContext, exceptionController);
            bool correct;
            ProductInfo productInfoGotten = productInfoRepository.Read(2);

            productInfoGotten.Product.ProductDescription = "Caja";

            correct = productInfoRepository.Update(productInfoGotten);

            ProductInfo productInfoCompare = productInfoRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productInfoCompare.Product, productInfoGotten.Product);

        }

        [Test]
        public void Delete_Test()
        {
            ProductInfoRepository productInfoRepository = new ProductInfoRepository(dbContext, exceptionController);
            bool correct;
            ProductInfo productInfoGotten = productInfoRepository.Read(1);

            correct = productInfoRepository.Delete(productInfoGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
