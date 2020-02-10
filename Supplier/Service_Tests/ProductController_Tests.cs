using Autofac;
using NUnit.Framework;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using Supplier_Service.Controllers;
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

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productController = scope.Resolve<ProductController>();

            this.productController.InsertProduct(new ProductSpecific("Pelota", 20, 5, true));
            this.productController.InsertProduct(new ProductSpecific("Peine", 4, 10, true));
            this.productController.InsertProduct(new ProductSpecific("Zapatillas Adidas", 80, 15, true));

        }

        [Test]
        public void AAProductsList_Test()
        {
            List<Product> currentProduct = this.productController.ProductsList();

            Assert.AreEqual(currentProduct[0].ProductDescription, "Pelota");
            Assert.AreEqual(currentProduct[1].ProductDescription, "Peine");
            Assert.AreEqual(currentProduct[2].ProductDescription, "Zapatillas Adidas");

        }

        [Test]
        public void InsertProduct_Test()
        {
            String message = this.productController.InsertProduct(new ProductSpecific("Teclado", 60, 20, true));

            Product productGotten = this.productController.GetProduct(4);

            Assert.AreEqual(message, "Product introduced satisfactorily.");
            Assert.AreEqual(productGotten.ProductDescription, "Teclado");
            Assert.AreEqual(productGotten.Prize, 60);
            Assert.AreEqual(productGotten.Cuantity, 20);

        }

        [Test]
        public void GetProduct_Test()
        {
            Product productGotten = this.productController.GetProduct(1);

            Assert.AreEqual(productGotten.ProductDescription, "Pelota");
            Assert.AreEqual(productGotten.Prize, 20);
            Assert.AreEqual(productGotten.Cuantity, 5);

        }

        [Test]
        public void UpdateProduct_Test()
        {
            ProductSpecific change = new ProductSpecific();
            change.ProductId = 2;
            change.ProductDescription = "Secador";
            change.Prize = 50;

            String message = this.productController.UpdateProduct(change);

            Product productGotten = this.productController.GetProduct(2);

            Assert.AreEqual(message, "Product updated satisfactorily.");
            Assert.AreEqual(productGotten.ProductDescription, "Secador");
            Assert.AreEqual(productGotten.Prize, 50);

        }

        [Test]
        public void DeleteProduct_Test()
        {
            String message = this.productController.DeleteProduct(3);

            Assert.AreEqual(message, "Product deleted satisfactorily.");

        }
    }
}
