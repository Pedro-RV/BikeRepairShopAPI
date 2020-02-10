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
    class ProductTypeRepository_Tests
    {
        private IProductTypeRepository productTypeRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productTypeRepository = scope.Resolve<IProductTypeRepository>();

            ProductType productTypeOne = new ProductType("Ruedas");
            ProductType productTypeTwo = new ProductType("Ventiladores");
            ProductType productTypeThree = new ProductType("Frenos");

            this.productTypeRepository.Insert(productTypeOne);
            this.productTypeRepository.Insert(productTypeTwo);
            this.productTypeRepository.Insert(productTypeThree);
        }

        [Test]
        public void Insert_Test()
        {
            ProductType productTypeAdd = new ProductType("Llantas");
            bool correct;

            correct = this.productTypeRepository.Insert(productTypeAdd);

            ProductType productTypeGotten = this.productTypeRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productTypeGotten.ProductTypeDescription, productTypeAdd.ProductTypeDescription);

        }

        [Test]
        public void Read_Test()
        {
            ProductType productTypeGotten = this.productTypeRepository.Read(3);

            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Frenos");

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            ProductType productTypeGotten = this.productTypeRepository.Read(2);

            productTypeGotten.ProductTypeDescription = "Herramientas";

            correct = this.productTypeRepository.Update(productTypeGotten);

            ProductType productTypeCompare = this.productTypeRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productTypeCompare.ProductTypeDescription, productTypeGotten.ProductTypeDescription);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            ProductType productTypeGotten = this.productTypeRepository.Read(1);

            correct = this.productTypeRepository.Delete(productTypeGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
