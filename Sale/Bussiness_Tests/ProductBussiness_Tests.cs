using Autofac;
using NUnit.Framework;
using Sale_Bussiness;
using Sale_Bussiness.Interfaces;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Tests
{
    [TestFixture]
    class ProductBussiness_Tests
    {
        private IProductBussiness productBussiness;
        private IProductTypeBussiness productTypeBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productBussiness = scope.Resolve<IProductBussiness>();
            this.productTypeBussiness = scope.Resolve<IProductTypeBussiness>();

            this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ruedas"));

            this.productBussiness.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            this.productBussiness.InsertProduct(new ProductSpecific("Ruedas Tractor", 200, 25, 1));
            this.productBussiness.InsertProduct(new ProductSpecific("Ruedas Grua", 350, 20, 1));

        }

        [Test]
        public void InsertProduct_Test()
        {
            bool correct;

            correct = this.productBussiness.InsertProduct(new ProductSpecific("Ruedas Armilla", 45, 60, 1));

            Product productGotten = this.productBussiness.ReadProduct(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, "Ruedas Armilla");
            Assert.AreEqual(productGotten.Prize, 45);
            Assert.AreEqual(productGotten.Cuantity, 60);

        }

        [Test]
        public void ReadProduct_Test()
        {
            Product productGotten = this.productBussiness.ReadProduct(1);

            Assert.AreEqual(productGotten.ProductDescription, "Ruedas Michelin");
            Assert.AreEqual(productGotten.Prize, 50);
            Assert.AreEqual(productGotten.Cuantity, 50);

        }

        [Test]
        public void UpdateProduct_Test()
        {
            bool correct;

            ProductSpecific change = new ProductSpecific();
            change.ProductId = 2;
            change.ProductDescription = "Ruedas China";
            change.Prize = 25;

            correct = this.productBussiness.UpdateProduct(change);

            Product productCompare = this.productBussiness.ReadProduct(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productCompare.ProductDescription, change.ProductDescription);
            Assert.AreEqual(productCompare.Prize, change.Prize);

        }

        [Test]
        public void DeleteProduct_Test()
        {
            bool correct;

            correct = this.productBussiness.DeleteProduct(3);

            Assert.AreEqual(true, correct);

        }
    }
}
