using NUnit.Framework;
using Sale_Data;
using Sale_Data.Context;
using Sale_Entities.EntityModel;
using Sale_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class ProductRepository_Tests
    {
        private SaleContext dbContext;
        private ExceptionController exceptionController;

        public ProductRepository_Tests()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            ProductType productType = new ProductType("Ruedas");
            Product productOne = new Product("Ruedas Michelin", 50, 50, productType);
            Product productTwo = new Product("Ruedas Tractor", 200, 25, productType);
            Product productThree = new Product("Ruedas Grua", 350, 20, productType);
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            productRepository.Insert(productOne);
            productRepository.Insert(productTwo);
            productRepository.Insert(productThree);
        }

        [Test]
        public void Insert_Test()
        {
            ProductType productType = new ProductType("Ruedas");
            Product productAdd = new Product("Ruedas Armilla", 45, 60, productType);
            bool correct;
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            correct = productRepository.Insert(productAdd);

            Product productGotten = productRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, productAdd.ProductDescription);
            Assert.AreEqual(productGotten.Prize, productAdd.Prize);
            Assert.AreEqual(productGotten.Cuantity, productAdd.Cuantity);
            Assert.AreEqual(productGotten.ProductType, productAdd.ProductType);

        }

        [Test]
        public void Read_Test()
        {
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            Product productGotten = productRepository.Read(3);

            Assert.AreEqual(productGotten.ProductDescription, "Ruedas Grua");
            Assert.AreEqual(productGotten.Prize, 350);
            Assert.AreEqual(productGotten.Cuantity, 20);

        }

        [Test]
        public void Update_Test()
        {
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);
            bool correct;
            Product productGotten = productRepository.Read(2);

            productGotten.ProductDescription = "Ruedas China";
            productGotten.Prize = 25;

            correct = productRepository.Update(productGotten);

            Product productCompare = productRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productCompare.ProductDescription, productGotten.ProductDescription);
            Assert.AreEqual(productCompare.Prize, productGotten.Prize);

        }

        [Test]
        public void Delete_Test()
        {
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);
            bool correct;
            Product productGotten = productRepository.Read(1);

            correct = productRepository.Delete(productGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
