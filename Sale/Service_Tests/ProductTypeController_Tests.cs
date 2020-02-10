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
    class ProductTypeController_Tests
    {
        private ProductTypeController productTypeController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productTypeController = scope.Resolve<ProductTypeController>();

            this.productTypeController.InsertProductType(new ProductTypeSpecific("Ruedas"));
            this.productTypeController.InsertProductType(new ProductTypeSpecific("Ventiladores"));
            this.productTypeController.InsertProductType(new ProductTypeSpecific("Frenos"));

        }

        [Test]
        public void InsertProductType_Test()
        {
            string message = this.productTypeController.InsertProductType(new ProductTypeSpecific("Llantas"));

            ProductType productTypeGotten = this.productTypeController.GetProductType(4);

            Assert.AreEqual(message, "ProductType introduced satisfactorily.");
            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Llantas");

        }

        [Test]
        public void GetProductType_Test()
        {
            ProductType productTypeGotten = this.productTypeController.GetProductType(1);

            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Ruedas");

        }

        [Test]
        public void UpdateProductType_Test()
        {
            ProductTypeSpecific change = new ProductTypeSpecific();
            change.ProductTypeId = 2;
            change.ProductTypeDescription = "Herramientas";

            string message = this.productTypeController.UpdateProductType(change);

            ProductType productTypeCompare = this.productTypeController.GetProductType(2);

            Assert.AreEqual(message, "ProductType updated satisfactorily.");
            Assert.AreEqual(productTypeCompare.ProductTypeDescription, change.ProductTypeDescription);

        }

        [Test]
        public void DeleteProductType_Test()
        {
            string message = this.productTypeController.DeleteProductType(3);

            Assert.AreEqual(message, "ProductType deleted satisfactorily.");

        }
    }
}
