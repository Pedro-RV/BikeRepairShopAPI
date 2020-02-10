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
        [TestFixtureSetUp]
        public void Init()
        {
            ProductTypeController productTypeController = new ProductTypeController();

            productTypeController.InsertProductType(new ProductTypeSpecific("Ruedas"));
            productTypeController.InsertProductType(new ProductTypeSpecific("Ventiladores"));
            productTypeController.InsertProductType(new ProductTypeSpecific("Frenos"));

        }

        [Test]
        public void InsertProductType_Test()
        {
            ProductTypeController productTypeController = new ProductTypeController();

            string message = productTypeController.InsertProductType(new ProductTypeSpecific("Llantas"));

            ProductType productTypeGotten = productTypeController.GetProductType(4);

            Assert.AreEqual(message, "ProductType introduced satisfactorily.");
            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Llantas");

        }

        [Test]
        public void GetProductType_Test()
        {
            ProductTypeController productTypeController = new ProductTypeController();

            ProductType productTypeGotten = productTypeController.GetProductType(3);

            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Frenos");

        }

        [Test]
        public void UpdateProductType_Test()
        {
            ProductTypeController productTypeController = new ProductTypeController();

            ProductTypeSpecific change = new ProductTypeSpecific();
            change.ProductTypeId = 2;
            change.ProductTypeDescription = "Herramientas";

            string message = productTypeController.UpdateProductType(change);

            ProductType productTypeCompare = productTypeController.GetProductType(2);

            Assert.AreEqual(message, "ProductType updated satisfactorily.");
            Assert.AreEqual(productTypeCompare.ProductTypeDescription, change.ProductTypeDescription);

        }

        [Test]
        public void DeleteProductType_Test()
        {
            ProductTypeController productTypeController = new ProductTypeController();

            string message = productTypeController.DeleteProductType(1);

            Assert.AreEqual(message, "ProductType deleted satisfactorily.");

        }
    }
}
