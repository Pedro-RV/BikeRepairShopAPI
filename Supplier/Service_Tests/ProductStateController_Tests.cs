//using NUnit.Framework;
//using Supplier_Entities.EntityModel;
//using Supplier_Entities.Specific;
//using Supplier_Service.Controllers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Service_Tests
//{
//    [TestFixture]
//    class ProductStateController_Tests
//    {
//        [TestFixtureSetUp]
//        public void Init()
//        {
//            ProductStateController productStateController = new ProductStateController();

//            productStateController.InsertProductState(new ProductStateSpecific("No disponible"));
//            productStateController.InsertProductState(new ProductStateSpecific("Sin existencias"));
//            productStateController.InsertProductState(new ProductStateSpecific("Con existencias"));

//        }

//        [Test]
//        public void InsertProductState_Test()
//        {
//            ProductStateController productStateController = new ProductStateController();

//            String message = productStateController.InsertProductState(new ProductStateSpecific("Fuera de venta"));

//            ProductState productStateGotten = productStateController.GetProductState(4);

//            Assert.AreEqual(message, "ProductState introduced satisfactorily.");
//            Assert.AreEqual(productStateGotten.ProductStateDescription, "Fuera de venta");

//        }

//        [Test]
//        public void GetProductState_Test()
//        {
//            ProductStateController productStateController = new ProductStateController();

//            ProductState productStateGotten = productStateController.GetProductState(1);

//            Assert.AreEqual(productStateGotten.ProductStateDescription, "No disponible");

//        }

//        [Test]
//        public void UpdateProductState_Test()
//        {
//            ProductStateController productStateController = new ProductStateController();

//            ProductStateSpecific change = new ProductStateSpecific();
//            change.ProductStateId = 2;
//            change.ProductStateDescription = "Agotado";

//            String message = productStateController.UpdateProductState(change);

//            ProductState productStateGotten = productStateController.GetProductState(2);

//            Assert.AreEqual(message, "ProductState updated satisfactorily.");
//            Assert.AreEqual(productStateGotten.ProductStateDescription, "Agotado");

//        }

//        [Test]
//        public void DeleteProductState_Test()
//        {
//            ProductStateController productStateController = new ProductStateController();

//            String message = productStateController.DeleteProductState(3);

//            Assert.AreEqual(message, "ProductState deleted satisfactorily.");

//        }
//    }
//}
