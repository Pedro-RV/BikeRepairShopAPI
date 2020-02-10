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
    class ProductRepository_Tests
    {
        private IProductRepository productRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productRepository = scope.Resolve<IProductRepository>();

            Product productOne = new Product("Pelota", 20, 5, true);
            Product productTwo = new Product("Peine", 4, 10, true);
            Product productThree = new Product("Zapatillas Adidas", 80, 15, true);

            this.productRepository.Insert(productOne);
            this.productRepository.Insert(productTwo);
            this.productRepository.Insert(productThree);
        }

        [Test]
        public void Insert_Test()
        {
            Product productAdd = new Product("Teclado", 60, 20, true);

            bool correct;

            correct = this.productRepository.Insert(productAdd);

            Product productGotten = this.productRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, productAdd.ProductDescription);
            Assert.AreEqual(productGotten.Prize, productAdd.Prize);
            Assert.AreEqual(productGotten.Cuantity, productAdd.Cuantity);

        }

        [Test]
        public void Read_Test()
        {
            Product productGotten = this.productRepository.Read(3);

            Assert.AreEqual(productGotten.ProductDescription, "Zapatillas Adidas");
            Assert.AreEqual(productGotten.Prize, 80);

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            Product productGotten = this.productRepository.Read(2);

            productGotten.ProductDescription = "Secador";
            productGotten.Prize = 50;

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
            Product productGotten = this.productRepository.Read(1);

            correct = this.productRepository.Delete(productGotten);

            Assert.AreEqual(true, correct);

        }

    }
}
