using Autofac;
using NUnit.Framework;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using Sale_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tests
{
    [TestFixture]
    class ProductController_Tests
    {
        private ProductController productController;
        private ProductTypeController productTypeController;      

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productController = scope.Resolve<ProductController>();
            this.productTypeController = scope.Resolve<ProductTypeController>();

            this.productTypeController.InsertProductType(new ProductTypeSpecific("Ruedas"));

            this.productController.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            this.productController.InsertProduct(new ProductSpecific("Ruedas Tractor", 200, 25, 1));
            this.productController.InsertProduct(new ProductSpecific("Ruedas Grua", 350, 20, 1));

        }

        [Test]
        public void InsertProduct_Test()
        {
            string message = this.productController.InsertProduct(new ProductSpecific("Ruedas Armilla", 45, 60, 1));

            Product productGotten = this.productController.GetProduct(4);

            Assert.AreEqual(message, "Product introduced satisfactorily.");
            Assert.AreEqual(productGotten.ProductDescription, "Ruedas Armilla");
            Assert.AreEqual(productGotten.Prize, 45);
            Assert.AreEqual(productGotten.Cuantity, 60);

        }

        [Test]
        public void GetProduct_Test()
        {
            Product productGotten = this.productController.GetProduct(1);

            Assert.AreEqual(productGotten.ProductDescription, "Ruedas Michelin");
            Assert.AreEqual(productGotten.Prize, 50);
            Assert.AreEqual(productGotten.Cuantity, 50);

        }

        [Test]
        public void UpdateProduct_Test()
        {
            ProductSpecific change = new ProductSpecific();
            change.ProductId = 2;
            change.ProductDescription = "Ruedas China";
            change.Prize = 25;

            string message = this.productController.UpdateProduct(change);

            Product productCompare = this.productController.GetProduct(2);

            Assert.AreEqual(message, "Product updated satisfactorily.");
            Assert.AreEqual(productCompare.ProductDescription, change.ProductDescription);
            Assert.AreEqual(productCompare.Prize, change.Prize);

        }

        [Test]
        public void DeleteProduct_Test()
        {
            string message = this.productController.DeleteProduct(3);

            Assert.AreEqual(message, "Product deleted satisfactorily.");

        }
    }
}
