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
    class ProductRepository_Tests
    {
        private SupplierContext dbContext;
        private ExceptionController exceptionController;

        public ProductRepository_Tests()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            Product productOne = new Product("Pelota", 20, 5, true);
            Product productTwo = new Product("Peine", 4, 10, true);
            Product productThree = new Product("Zapatillas Adidas", 80, 15, true);


            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            productRepository.Insert(productOne);
            productRepository.Insert(productTwo);
            productRepository.Insert(productThree);
        }

        [Test]
        public void Insert_Test()
        {
            Product productAdd = new Product("Teclado", 60, 20, true);

            bool correct;
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            correct = productRepository.Insert(productAdd);

            Product productGotten = productRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, productAdd.ProductDescription);
            Assert.AreEqual(productGotten.Prize, productAdd.Prize);
            Assert.AreEqual(productGotten.Cuantity, productAdd.Cuantity);

        }

        [Test]
        public void Read_Test()
        {
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            Product productGotten = productRepository.Read(3);

            Assert.AreEqual(productGotten.ProductDescription, "Zapatillas Adidas");
            Assert.AreEqual(productGotten.Prize, 80);

        }

        [Test]
        public void Update_Test()
        {
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);
            bool correct;
            Product productGotten = productRepository.Read(2);

            productGotten.ProductDescription = "Secador";
            productGotten.Prize = 50;

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
