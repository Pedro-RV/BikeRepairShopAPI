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
    class ProductTypeRepository_Tests
    {
        private SaleContext dbContext;
        private ExceptionController exceptionController;

        public ProductTypeRepository_Tests()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            ProductType productTypeOne = new ProductType("Ruedas");
            ProductType productTypeTwo = new ProductType("Ventiladores");
            ProductType productTypeThree = new ProductType("Frenos");
            ProductTypeRepository productTypeRepository = new ProductTypeRepository(dbContext, exceptionController);

            productTypeRepository.Insert(productTypeOne);
            productTypeRepository.Insert(productTypeTwo);
            productTypeRepository.Insert(productTypeThree);
        }

        [Test]
        public void Insert_Test()
        {
            ProductType productTypeAdd = new ProductType("Llantas");
            bool correct;
            ProductTypeRepository productTypeRepository = new ProductTypeRepository(dbContext, exceptionController);

            correct = productTypeRepository.Insert(productTypeAdd);

            ProductType productTypeGotten = productTypeRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productTypeGotten.ProductTypeDescription, productTypeAdd.ProductTypeDescription);

        }

        [Test]
        public void Read_Test()
        {
            ProductTypeRepository productTypeRepository = new ProductTypeRepository(dbContext, exceptionController);

            ProductType productTypeGotten = productTypeRepository.Read(3);

            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Frenos");

        }

        [Test]
        public void Update_Test()
        {
            ProductTypeRepository productTypeRepository = new ProductTypeRepository(dbContext, exceptionController);
            bool correct;
            ProductType productTypeGotten = productTypeRepository.Read(2);

            productTypeGotten.ProductTypeDescription = "Herramientas";

            correct = productTypeRepository.Update(productTypeGotten);

            ProductType productTypeCompare = productTypeRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productTypeCompare.ProductTypeDescription, productTypeGotten.ProductTypeDescription);

        }

        [Test]
        public void Delete_Test()
        {
            ProductTypeRepository productTypeRepository = new ProductTypeRepository(dbContext, exceptionController);
            bool correct;
            ProductType productTypeGotten = productTypeRepository.Read(1);

            correct = productTypeRepository.Delete(productTypeGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
