using Autofac;
using NUnit.Framework;
using Sale_Data;
using Sale_Data.Context;
using Sale_Data.Interfaces;
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
        private IProductRepository productRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productRepository = scope.Resolve<IProductRepository>();

            ProductType productType = new ProductType("Ruedas");
            Product productOne = new Product("Ruedas Michelin", 50, 50, productType);
            Product productTwo = new Product("Ruedas Tractor", 200, 25, productType);
            Product productThree = new Product("Ruedas Grua", 350, 20, productType);

            this.productRepository.Insert(productOne);
            this.productRepository.Insert(productTwo);
            this.productRepository.Insert(productThree);
        }

        [Test]
        public void Insert_Test()
        {
            ProductType productType = new ProductType("Ruedas");
            Product productAdd = new Product("Ruedas Armilla", 45, 60, productType);
            bool correct;

            correct = this.productRepository.Insert(productAdd);

            Product productGotten = this.productRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, productAdd.ProductDescription);
            Assert.AreEqual(productGotten.Prize, productAdd.Prize);
            Assert.AreEqual(productGotten.Cuantity, productAdd.Cuantity);
            Assert.AreEqual(productGotten.ProductType, productAdd.ProductType);

        }

        [Test]
        public void Read_Test()
        {
            Product productGotten = this.productRepository.Read(1);

            Assert.AreEqual(productGotten.ProductDescription, "Ruedas Michelin");
            Assert.AreEqual(productGotten.Prize, 50);
            Assert.AreEqual(productGotten.Cuantity, 50);

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            Product productGotten = this.productRepository.Read(2);

            productGotten.ProductDescription = "Ruedas China";
            productGotten.Prize = 25;

            correct = this.productRepository.Update(productGotten);

            Product productCompare = this.productRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productCompare.ProductDescription, productGotten.ProductDescription);
            Assert.AreEqual(productCompare.Prize, productGotten.Prize);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            Product productGotten = this.productRepository.Read(3);

            correct = this.productRepository.Delete(productGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
