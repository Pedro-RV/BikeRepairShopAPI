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
    class ProductController_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            EmployeeController employeeController = new EmployeeController();
            employeeController.InsertEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);            
            WarehouseController warehouseController = new WarehouseController();
            warehouseController.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));
            WarehouseAdminController warehouseAdminController = new WarehouseAdminController();
            warehouseAdminController.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));
            ProductStateController productStateController = new ProductStateController();
            productStateController.InsertProductState(new ProductStateSpecific("No disponible"));

            ProductController productController = new ProductController();

            productController.InsertProduct(new ProductSpecific("Pelota", 20, 5, 1, 1));
            productController.InsertProduct(new ProductSpecific("Peine", 4, 10, 1, 1));
            productController.InsertProduct(new ProductSpecific("Zapatillas Adidas", 80, 15, 1, 1));

        }

        [Test]
        public void AAProductsList_Test()
        {
            ProductController productController = new ProductController();

            List<Product> currentProduct = productController.ProductsList();

            Assert.AreEqual(currentProduct[0].ProductDescription, "Pelota");
            Assert.AreEqual(currentProduct[1].ProductDescription, "Peine");
            Assert.AreEqual(currentProduct[2].ProductDescription, "Zapatillas Adidas");

        }

        [Test]
        public void AAProductDataList_Test()
        {
            ProductController productController = new ProductController();

            List<ProductData> currentProductData = productController.ProductDataList();

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
            ProductController productController = new ProductController();

            String message = productController.InsertProduct(new ProductSpecific("Teclado", 60, 20, 1, 1));

            Product productGotten = productController.GetProduct(4);

            Assert.AreEqual(message, "Product introduced satisfactorily.");
            Assert.AreEqual(productGotten.ProductDescription, "Teclado");
            Assert.AreEqual(productGotten.Prize, 60);
            Assert.AreEqual(productGotten.Cuantity, 20);

        }

        [Test]
        public void GetProduct_Test()
        {
            ProductController productController = new ProductController();

            Product productGotten = productController.GetProduct(1);

            Assert.AreEqual(productGotten.ProductDescription, "Pelota");
            Assert.AreEqual(productGotten.Prize, 20);
            Assert.AreEqual(productGotten.Cuantity, 5);

        }

        [Test]
        public void UpdateProduct_Test()
        {
            ProductController productController = new ProductController();

            ProductSpecific change = new ProductSpecific();
            change.ProductId = 2;
            change.ProductDescription = "Secador";
            change.Prize = 50;

            String message = productController.UpdateProduct(change);

            Product productGotten = productController.GetProduct(2);

            Assert.AreEqual(message, "Product updated satisfactorily.");
            Assert.AreEqual(productGotten.ProductDescription, "Secador");
            Assert.AreEqual(productGotten.Prize, 50);

        }

        [Test]
        public void DeleteProduct_Test()
        {
            ProductController productController = new ProductController();

            String message = productController.DeleteProduct(3);

            Assert.AreEqual(message, "Product deleted satisfactorily.");

        }
    }
}
