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
        [TestFixtureSetUp]
        public void Init()
        {
            ProductTypeController productTypeController = new ProductTypeController();
            productTypeController.InsertProductType(new ProductTypeSpecific("Ruedas"));

            ProductController productController = new ProductController();

            productController.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            productController.InsertProduct(new ProductSpecific("Ruedas Tractor", 200, 25, 1));
            productController.InsertProduct(new ProductSpecific("Ruedas Grua", 350, 20, 1));

        }

        [Test]
        public void InsertProduct_Test()
        {
            ProductController productController = new ProductController();

            string message = productController.InsertProduct(new ProductSpecific("Ruedas Armilla", 45, 60, 1));

            Product productGotten = productController.GetProduct(4);

            Assert.AreEqual(message, "Product introduced satisfactorily.");
            Assert.AreEqual(productGotten.ProductDescription, "Ruedas Armilla");
            Assert.AreEqual(productGotten.Prize, 45);
            Assert.AreEqual(productGotten.Cuantity, 60);

        }

        [Test]
        public void GetProduct_Test()
        {
            ProductController productController = new ProductController();

            Product productGotten = productController.GetProduct(3);

            Assert.AreEqual(productGotten.ProductDescription, "Ruedas Grua");
            Assert.AreEqual(productGotten.Prize, 350);
            Assert.AreEqual(productGotten.Cuantity, 20);

        }

        [Test]
        public void UpdateProduct_Test()
        {
            ProductController productController = new ProductController();

            ProductSpecific change = new ProductSpecific();
            change.ProductId = 2;
            change.ProductDescription = "Ruedas China";
            change.Prize = 25;

            string message = productController.UpdateProduct(change);

            Product productCompare = productController.GetProduct(2);

            Assert.AreEqual(message, "Product updated satisfactorily.");
            Assert.AreEqual(productCompare.ProductDescription, change.ProductDescription);
            Assert.AreEqual(productCompare.Prize, change.Prize);

        }

        [Test]
        public void DeleteProduct_Test()
        {
            ProductController productController = new ProductController();

            string message = productController.DeleteProduct(1);

            Assert.AreEqual(message, "Product deleted satisfactorily.");

        }
    }
}
