using Autofac;
using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Tests
{
    [TestFixture]
    class ProductStateBussiness_Tests
    {
        private IProductStateBussiness productStateBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productStateBussiness = scope.Resolve<IProductStateBussiness>();

            this.productStateBussiness.InsertProductState(new ProductStateSpecific("No disponible"));
            this.productStateBussiness.InsertProductState(new ProductStateSpecific("Sin existencias"));
            this.productStateBussiness.InsertProductState(new ProductStateSpecific("Con existencias"));

        }

        [Test]
        public void InsertProductState_Test()
        {
            bool correct;

            correct = this.productStateBussiness.InsertProductState(new ProductStateSpecific("Fuera de venta"));

            ProductState productStateGotten = this.productStateBussiness.ReadProductState(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productStateGotten.ProductStateDescription, "Fuera de venta");

        }

        [Test]
        public void ReadProductState_Test()
        {
            ProductState productStateGotten = this.productStateBussiness.ReadProductState(1);

            Assert.AreEqual(productStateGotten.ProductStateDescription, "No disponible");

        }

        [Test]
        public void UpdateProductState_Test()
        {
            bool correct;

            ProductStateSpecific change = new ProductStateSpecific();
            change.ProductStateId = 2;
            change.ProductStateDescription = "Agotado";

            correct = this.productStateBussiness.UpdateProductState(change);

            ProductState productStateGotten = this.productStateBussiness.ReadProductState(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productStateGotten.ProductStateDescription, "Agotado");

        }

        [Test]
        public void DeleteProductState_Test()
        {
            bool correct;

            correct = this.productStateBussiness.DeleteProductState(3);

            Assert.AreEqual(true, correct);

        }
    }
}
