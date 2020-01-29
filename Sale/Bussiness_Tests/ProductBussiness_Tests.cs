using NUnit.Framework;
using Sale_Bussiness;
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
        [TestFixtureSetUp]
        public void Init()
        {
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();
            productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ruedas"));

            ProductBussiness productBussiness = new ProductBussiness();

            productBussiness.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            productBussiness.InsertProduct(new ProductSpecific("Ruedas Tractor", 200, 25, 1));
            productBussiness.InsertProduct(new ProductSpecific("Ruedas Grua", 350, 20, 1));

        }

        [Test]
        public void InsertProduct_Test()
        {
            bool correct;
            ProductBussiness productBussiness = new ProductBussiness();

            correct = productBussiness.InsertProduct(new ProductSpecific("Ruedas Armilla", 45, 60, 1));

            Product productGotten = productBussiness.ReadProduct(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, "Ruedas Armilla");
            Assert.AreEqual(productGotten.Prize, 45);
            Assert.AreEqual(productGotten.Cuantity, 60);

        }

        [Test]
        public void ReadProduct_Test()
        {
            ProductBussiness productBussiness = new ProductBussiness();

            Product productGotten = productBussiness.ReadProduct(3);

            Assert.AreEqual(productGotten.ProductDescription, "Ruedas Grua");
            Assert.AreEqual(productGotten.Prize, 350);
            Assert.AreEqual(productGotten.Cuantity, 20);

        }

        [Test]
        public void UpdateProduct_Test()
        {
            ProductBussiness productBussiness = new ProductBussiness();
            bool correct;

            ProductSpecific change = new ProductSpecific();
            change.ProductId = 2;
            change.ProductDescription = "Ruedas China";
            change.Prize = 25;

            correct = productBussiness.UpdateProduct(change);

            Product productCompare = productBussiness.ReadProduct(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productCompare.ProductDescription, change.ProductDescription);
            Assert.AreEqual(productCompare.Prize, change.Prize);

        }

        [Test]
        public void DeleteProduct_Test()
        {
            ProductBussiness productBussiness = new ProductBussiness();
            bool correct;

            correct = productBussiness.DeleteProduct(1);

            Assert.AreEqual(true, correct);

        }
    }
}
