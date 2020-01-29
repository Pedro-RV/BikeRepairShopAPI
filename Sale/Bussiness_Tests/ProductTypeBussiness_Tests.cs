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
    class ProductTypeBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();

            productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ruedas"));
            productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ventiladores"));
            productTypeBussiness.InsertProductType(new ProductTypeSpecific("Frenos"));

        }

        [Test]
        public void InsertProductType_Test()
        {
            bool correct;
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();

            correct = productTypeBussiness.InsertProductType(new ProductTypeSpecific("Llantas"));

            ProductType productTypeGotten = productTypeBussiness.ReadProductType(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Llantas");

        }

        [Test]
        public void ReadClient_Test()
        {
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();

            ProductType productTypeGotten = productTypeBussiness.ReadProductType(3);

            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Frenos");

        }

        [Test]
        public void UpdateClient_Test()
        {
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();
            bool correct;

            ProductTypeSpecific change = new ProductTypeSpecific();
            change.ProductTypeId = 2;
            change.ProductTypeDescription = "Herramientas";

            correct = productTypeBussiness.UpdateProductType(change);

            ProductType productTypeCompare = productTypeBussiness.ReadProductType(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productTypeCompare.ProductTypeDescription, change.ProductTypeDescription);

        }

        [Test]
        public void DeleteClient_Test()
        {
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();
            bool correct;

            correct = productTypeBussiness.DeleteProductType(1);

            Assert.AreEqual(true, correct);

        }
    }
}
