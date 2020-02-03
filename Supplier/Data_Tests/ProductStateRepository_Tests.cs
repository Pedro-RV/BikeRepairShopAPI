//using NUnit.Framework;
//using Supplier_Data;
//using Supplier_Data.Context;
//using Supplier_Entities.EntityModel;
//using Supplier_Helper.ExceptionController;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Data_Tests
//{
//    class ProductStateRepository_Tests
//    {
//        private SupplierContext dbContext;
//        private ExceptionController exceptionController;

//        public ProductStateRepository_Tests()
//        {
//            SupplierContextProvider.InitializeSupplierContext();
//            dbContext = SupplierContextProvider.GetSupplierContext();
//            exceptionController = new ExceptionController();
//        }

//        [TestFixtureSetUp]
//        public void Init()
//        {
//            ProductState productStateOne = new ProductState("No disponible");
//            ProductState productStateTwo = new ProductState("Sin existencias");
//            ProductState productStateThree = new ProductState("Con existencias");


//            ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);

//            productStateRepository.Insert(productStateOne);
//            productStateRepository.Insert(productStateTwo);
//            productStateRepository.Insert(productStateThree);
//        }

//        [Test]
//        public void Insert_Test()
//        {
//            ProductState productStateAdd = new ProductState("Fuera de venta");

//            bool correct;
//            ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);

//            correct = productStateRepository.Insert(productStateAdd);

//            ProductState productStateGotten = productStateRepository.Read(4);

//            Assert.AreEqual(true, correct);
//            Assert.AreEqual(productStateGotten.ProductStateDescription, productStateAdd.ProductStateDescription);

//        }

//        [Test]
//        public void Read_Test()
//        {
//            ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);

//            ProductState productStateGotten = productStateRepository.Read(3);

//            Assert.AreEqual(productStateGotten.ProductStateDescription, "Con existencias");

//        }

//        [Test]
//        public void Update_Test()
//        {
//            ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);
//            bool correct;
//            ProductState productStateGotten = productStateRepository.Read(2);

//            productStateGotten.ProductStateDescription = "Agotado";

//            correct = productStateRepository.Update(productStateGotten);

//            ProductState productCompare = productStateRepository.Read(2);

//            Assert.AreEqual(true, correct);
//            Assert.AreEqual(productCompare.ProductStateDescription, productStateGotten.ProductStateDescription);

//        }

//        [Test]
//        public void Delete_Test()
//        {
//            ProductStateRepository productStateRepository = new ProductStateRepository(dbContext, exceptionController);
//            bool correct;
//            ProductState productStateGotten = productStateRepository.Read(1);

//            correct = productStateRepository.Delete(productStateGotten);

//            Assert.AreEqual(true, correct);

//        }
//    }
//}
