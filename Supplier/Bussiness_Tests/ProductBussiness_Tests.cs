using Autofac;
using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
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

            this.productBussiness.InsertProduct(new ProductSpecific("Pelota", 20, 5, true, 1));
            this.productBussiness.InsertProduct(new ProductSpecific("Peine", 4, 10, true, 1));
            this.productBussiness.InsertProduct(new ProductSpecific("Zapatillas Adidas", 80, 15, true, 1));

        }

        [Test]
        public void AAProductsList_Test()
        {
            List<Product> currentProduct = this.productBussiness.ProductsList();

            Assert.AreEqual(currentProduct[0].ProductDescription, "Pelota");
            Assert.AreEqual(currentProduct[1].ProductDescription, "Peine");
            Assert.AreEqual(currentProduct[2].ProductDescription, "Zapatillas Adidas");

        }

        [Test]
        public void InsertProduct_Test()
        {
            bool correct;

            correct = this.productBussiness.InsertProduct(new ProductSpecific("Teclado", 60, 20, true, 1));

            Product productGotten = this.productBussiness.ReadProduct(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, "Teclado");
            Assert.AreEqual(productGotten.Prize, 60);
            Assert.AreEqual(productGotten.Cuantity, 20);

        }

        [Test]
        public void ReadProduct_Test()
        {
            Product productGotten = this.productBussiness.ReadProduct(1);

            Assert.AreEqual(productGotten.ProductDescription, "Pelota");
            Assert.AreEqual(productGotten.Prize, 20);
            Assert.AreEqual(productGotten.Cuantity, 5);

        }

        [Test]
        public void UpdateProduct_Test()
        {
            bool correct;

            ProductSpecific change = new ProductSpecific();
            change.ProductId = 2;
            change.ProductDescription = "Secador";
            change.Prize = 50;

            correct = this.productBussiness.UpdateProduct(change);

            Product productGotten = this.productBussiness.ReadProduct(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, "Secador");
            Assert.AreEqual(productGotten.Prize, 50);

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
