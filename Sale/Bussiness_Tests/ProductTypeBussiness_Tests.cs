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
    class ProductTypeBussiness_Tests
    {
        private IProductTypeBussiness productTypeBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productTypeBussiness = scope.Resolve<IProductTypeBussiness>();

            this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ruedas"));
            this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ventiladores"));
            this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Frenos"));

        }

        [Test]
        public void InsertProductType_Test()
        {
            bool correct;

            correct = this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Llantas"));

            ProductType productTypeGotten = this.productTypeBussiness.ReadProductType(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Llantas");

        }

        [Test]
        public void ReadProductType_Test()
        {
            ProductType productTypeGotten = this.productTypeBussiness.ReadProductType(3);

            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Frenos");

        }

        [Test]
        public void UpdateProductType_Test()
        {
            bool correct;

            ProductTypeSpecific change = new ProductTypeSpecific();
            change.ProductTypeId = 2;
            change.ProductTypeDescription = "Herramientas";

            correct = this.productTypeBussiness.UpdateProductType(change);

            ProductType productTypeCompare = this.productTypeBussiness.ReadProductType(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productTypeCompare.ProductTypeDescription, change.ProductTypeDescription);

        }

        [Test]
        public void DeleteProductType_Test()
        {
            bool correct;

            correct = this.productTypeBussiness.DeleteProductType(1);

            Assert.AreEqual(true, correct);

        }
    }
}
