//using NUnit.Framework;
//using Supplier_Bussiness;
//using Supplier_Entities.EntityModel;
//using Supplier_Entities.Specific;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bussiness_Tests
//{
//    [TestFixture]
//    class ProductBussiness_Tests
//    {
//        [TestFixtureSetUp]
//        public void Init()
//        {
//            ProductBussiness productBussiness = new ProductBussiness();

//            productBussiness.InsertProduct(new ProductSpecific("Pelota", 20, 5, true));
//            productBussiness.InsertProduct(new ProductSpecific("Peine", 4, 10, true));
//            productBussiness.InsertProduct(new ProductSpecific("Zapatillas Adidas", 80, 15, true));

//        }

//        [Test]
//        public void AAProductsList_Test()
//        {
//            ProductBussiness productBussiness = new ProductBussiness();

//            List<Product> currentProduct = productBussiness.ProductsList();

//            Assert.AreEqual(currentProduct[0].ProductDescription, "Pelota");
//            Assert.AreEqual(currentProduct[1].ProductDescription, "Peine");
//            Assert.AreEqual(currentProduct[2].ProductDescription, "Zapatillas Adidas");

//        }

//        [Test]
//        public void InsertProduct_Test()
//        {
//            bool correct;
//            ProductBussiness productBussiness = new ProductBussiness();

//            correct = productBussiness.InsertProduct(new ProductSpecific("Teclado", 60, 20, true));

//            Product productGotten = productBussiness.ReadProduct(4);

//            Assert.AreEqual(true, correct);
//            Assert.AreEqual(productGotten.ProductDescription, "Teclado");
//            Assert.AreEqual(productGotten.Prize, 60);
//            Assert.AreEqual(productGotten.Cuantity, 20);

//        }

//        [Test]
//        public void ReadProduct_Test()
//        {
//            ProductBussiness productBussiness = new ProductBussiness();

//            Product productGotten = productBussiness.ReadProduct(1);

//            Assert.AreEqual(productGotten.ProductDescription, "Pelota");
//            Assert.AreEqual(productGotten.Prize, 20);
//            Assert.AreEqual(productGotten.Cuantity, 5);

//        }

//        [Test]
//        public void UpdateProduct_Test()
//        {
//            bool correct;
//            ProductBussiness productBussiness = new ProductBussiness();

//            ProductSpecific change = new ProductSpecific();
//            change.ProductId = 2;
//            change.ProductDescription = "Secador";
//            change.Prize = 50;

//            correct = productBussiness.UpdateProduct(change);

//            Product productGotten = productBussiness.ReadProduct(2);

//            Assert.AreEqual(true, correct);
//            Assert.AreEqual(productGotten.ProductDescription, "Secador");
//            Assert.AreEqual(productGotten.Prize, 50);

//        }

//        [Test]
//        public void DeleteProduct_Test()
//        {
//            bool correct;
//            ProductBussiness productBussiness = new ProductBussiness();

//            correct = productBussiness.DeleteProduct(3);

//            Assert.AreEqual(true, correct);

//        }
//    }
//}
