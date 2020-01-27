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
        [TestFixtureSetUp]
        public void Init()
        {
            ProductController productController = new ProductController();

            productController.InsertProduct(new ProductSpecific("Pelota", 20, 5, true));
            productController.InsertProduct(new ProductSpecific("Peine", 4, 10, true));
            productController.InsertProduct(new ProductSpecific("Zapatillas Adidas", 80, 15, true));

        }

        [Test]
        public void AAProductsList_Test()
        {
            ProductController productController = new ProductController();

            List<Product> currentProduct = productController.ProductsList();

            Assert.AreEqual(currentProduct[0].ProductDescription, "Pelota");
            Assert.AreEqual(currentProduct[1].ProductDescription, "Peine");
            Assert.AreEqual(currentProduct[2].ProductDescription, "Zapatillas Adidas");

        }

        [Test]
        public void InsertProduct_Test()
        {
            ProductController productController = new ProductController();

            String message = productController.InsertProduct(new ProductSpecific("Teclado", 60, 20, true));

            Product productGotten = productController.GetProduct(4);

            Assert.AreEqual(message, "Product introduced satisfactorily.");
            Assert.AreEqual(productGotten.ProductDescription, "Teclado");
            Assert.AreEqual(productGotten.Prize, 60);
            Assert.AreEqual(productGotten.Cuantity, 20);

        }

        [Test]
        public void GetProduct_Test()
        {
            ProductController productController = new ProductController();

            Product productGotten = productController.GetProduct(1);

            Assert.AreEqual(productGotten.ProductDescription, "Pelota");
            Assert.AreEqual(productGotten.Prize, 20);
            Assert.AreEqual(productGotten.Cuantity, 5);

        }

        [Test]
        public void UpdateProduct_Test()
        {
            ProductController productController = new ProductController();

            ProductSpecific change = new ProductSpecific();
            change.ProductId = 2;
            change.ProductDescription = "Secador";
            change.Prize = 50;

            String message = productController.UpdateProduct(change);

            Product productGotten = productController.GetProduct(2);

            Assert.AreEqual(message, "Product updated satisfactorily.");
            Assert.AreEqual(productGotten.ProductDescription, "Secador");
            Assert.AreEqual(productGotten.Prize, 50);

        }

        [Test]
        public void DeleteProduct_Test()
        {
            ProductController productController = new ProductController();

            String message = productController.DeleteProduct(3);

            Assert.AreEqual(message, "Product deleted satisfactorily.");

        }
    }
}
