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
    class ProductStateController_Tests
    {
        private ProductStateController productStateController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productStateController = scope.Resolve<ProductStateController>();

            this.productStateController.InsertProductState(new ProductStateSpecific("No disponible"));
            this.productStateController.InsertProductState(new ProductStateSpecific("Sin existencias"));
            this.productStateController.InsertProductState(new ProductStateSpecific("Con existencias"));

        }

        [Test]
        public void InsertProductState_Test()
        {
            string message = this.productStateController.InsertProductState(new ProductStateSpecific("Fuera de venta"));

            ProductState productStateGotten = this.productStateController.GetProductState(4);

            Assert.AreEqual(message, "ProductState introduced satisfactorily.");
            Assert.AreEqual(productStateGotten.ProductStateDescription, "Fuera de venta");

        }

        [Test]
        public void GetProductState_Test()
        {
            ProductState productStateGotten = this.productStateController.GetProductState(1);

            Assert.AreEqual(productStateGotten.ProductStateDescription, "No disponible");

        }

        [Test]
        public void UpdateProductState_Test()
        {
            ProductStateSpecific change = new ProductStateSpecific();
            change.ProductStateId = 2;
            change.ProductStateDescription = "Agotado";

            string message = this.productStateController.UpdateProductState(change);

            ProductState productStateGotten = this.productStateController.GetProductState(2);

            Assert.AreEqual(message, "ProductState updated satisfactorily.");
            Assert.AreEqual(productStateGotten.ProductStateDescription, "Agotado");

        }

        [Test]
        public void DeleteProductState_Test()
        {
            string message = this.productStateController.DeleteProductState(3);

            Assert.AreEqual(message, "ProductState deleted satisfactorily.");

        }
    }
}
