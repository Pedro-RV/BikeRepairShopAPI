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
    class ProductBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();
            employeeBussiness.InsertEmployee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();
            warehouseAdminBussiness.InsertWarehouseAdmin(dateTime, 1);
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();
            warehouseBussiness.InsertWarehouse("Calle Ebro", 120, 1);
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();
            productStateBussiness.InsertProductState("No disponible");

            ProductBussiness productBussiness = new ProductBussiness();

            productBussiness.InsertProduct("Pelota", 20, 5, 1, 1);
            productBussiness.InsertProduct("Peine", 4, 10, 1, 1);
            productBussiness.InsertProduct("Zapatillas Adidas", 80, 15, 1, 1);

        }

        [Test]
        public void AAProductsList_Test()
        {
            ProductBussiness productBussiness = new ProductBussiness();

            List<Product> currentProduct = productBussiness.ProductsList();

            Assert.AreEqual(currentProduct[0].ProductDescription, "Pelota");
            Assert.AreEqual(currentProduct[1].ProductDescription, "Peine");
            Assert.AreEqual(currentProduct[2].ProductDescription, "Zapatillas Adidas");

        }

        [Test]
        public void AAProductDataList_Test()
        {
            ProductBussiness productBussiness = new ProductBussiness();

            List<ProductData> currentProductData = productBussiness.ProductDataList();

            Assert.AreEqual(currentProductData[0].ProductName, "Pelota");
            Assert.AreEqual(currentProductData[0].ProductStateName, "No disponible");
            Assert.AreEqual(currentProductData[1].ProductName, "Peine");
            Assert.AreEqual(currentProductData[1].ProductStateName, "No disponible");
            Assert.AreEqual(currentProductData[2].ProductName, "Zapatillas Adidas");
            Assert.AreEqual(currentProductData[2].ProductStateName, "No disponible");

        }

        [Test]
        public void InsertProduct_Test()
        {
            bool correct;
            ProductBussiness productBussiness = new ProductBussiness();

            correct = productBussiness.InsertProduct("Teclado", 60, 20, 1, 1);

            Product productGotten = productBussiness.ReadProduct(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, "Teclado");
            Assert.AreEqual(productGotten.Prize, 60);
            Assert.AreEqual(productGotten.Cuantity, 20);

        }

        [Test]
        public void ReadProduct_Test()
        {
            ProductBussiness productBussiness = new ProductBussiness();

            Product productGotten = productBussiness.ReadProduct(1);

            Assert.AreEqual(productGotten.ProductDescription, "Pelota");
            Assert.AreEqual(productGotten.Prize, 20);
            Assert.AreEqual(productGotten.Cuantity, 5);

        }

        [Test]
        public void UpdateProduct_Test()
        {
            bool correct;
            ProductBussiness productBussiness = new ProductBussiness();

            Product change = productBussiness.ReadProduct(2);
            change.ProductDescription = "Secador";
            change.Prize = 50;

            correct = productBussiness.UpdateProduct(change);

            Product productGotten = productBussiness.ReadProduct(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, "Secador");
            Assert.AreEqual(productGotten.Prize, 50);

        }

        [Test]
        public void DeleteProduct_Test()
        {
            bool correct;
            ProductBussiness productBussiness = new ProductBussiness();

            correct = productBussiness.DeleteProduct(3);

            Assert.AreEqual(true, correct);

        }
    }
}
