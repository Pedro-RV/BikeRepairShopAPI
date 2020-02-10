using Autofac;
using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class ProductStateRepository_Tests
    {
        private IProductStateRepository productStateRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productStateRepository = scope.Resolve<IProductStateRepository>();

            ProductState productStateOne = new ProductState("No disponible");
            ProductState productStateTwo = new ProductState("Sin existencias");
            ProductState productStateThree = new ProductState("Con existencias");

            this.productStateRepository.Insert(productStateOne);
            this.productStateRepository.Insert(productStateTwo);
            this.productStateRepository.Insert(productStateThree);
        }

        [Test]
        public void Insert_Test()
        {
            ProductState productStateAdd = new ProductState("Fuera de venta");

            bool correct;

            correct = this.productStateRepository.Insert(productStateAdd);

            ProductState productStateGotten = this.productStateRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productStateGotten.ProductStateDescription, productStateAdd.ProductStateDescription);

        }

        [Test]
        public void Read_Test()
        {
            ProductState productStateGotten = this.productStateRepository.Read(3);

            Assert.AreEqual(productStateGotten.ProductStateDescription, "Con existencias");

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            ProductState productStateGotten = this.productStateRepository.Read(2);

            productStateGotten.ProductStateDescription = "Agotado";

            correct = this.productStateRepository.Update(productStateGotten);

            ProductState productCompare = this.productStateRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productCompare.ProductStateDescription, productStateGotten.ProductStateDescription);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            ProductState productStateGotten = this.productStateRepository.Read(1);

            correct = this.productStateRepository.Delete(productStateGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
