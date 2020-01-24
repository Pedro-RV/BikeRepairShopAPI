using NUnit.Framework;
using Supplier_Bussiness;
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
    class ProductStateBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            productStateBussiness.InsertProductState(new ProductStateSpecific("No disponible"));
            productStateBussiness.InsertProductState(new ProductStateSpecific("Sin existencias"));
            productStateBussiness.InsertProductState(new ProductStateSpecific("Con existencias"));

        }

        [Test]
        public void InsertProductState_Test()
        {
            bool correct;
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            correct = productStateBussiness.InsertProductState(new ProductStateSpecific("Fuera de venta"));

            ProductState productStateGotten = productStateBussiness.ReadProductState(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productStateGotten.ProductStateDescription, "Fuera de venta");

        }

        [Test]
        public void ReadProductState_Test()
        {
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            ProductState productStateGotten = productStateBussiness.ReadProductState(1);

            Assert.AreEqual(productStateGotten.ProductStateDescription, "No disponible");

        }

        [Test]
        public void UpdateProductState_Test()
        {
            bool correct;
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            ProductStateSpecific change = new ProductStateSpecific();
            change.ProductStateId = 2;
            change.ProductStateDescription = "Agotado";

            correct = productStateBussiness.UpdateProductState(change);

            ProductState productStateGotten = productStateBussiness.ReadProductState(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productStateGotten.ProductStateDescription, "Agotado");

        }

        [Test]
        public void DeleteProductState_Test()
        {
            bool correct;
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            correct = productStateBussiness.DeleteProductState(3);

            Assert.AreEqual(true, correct);

        }
    }
}
