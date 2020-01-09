using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    class ProductRepository_Tests
    {
        private SupplierContext dbContext;
        private ExceptionController exceptionController;

        public ProductRepository_Tests()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            Employee employee = new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            WarehouseAdmin warehouseAdmin = new WarehouseAdmin(dateTime, employee);
            Warehouse warehouse = new Warehouse("Calle Ebro", 120, warehouseAdmin);
            ProductState productState = new ProductState("No disponible");

            Product productOne = new Product("Pelota", 20, 5, warehouse, productState);
            Product productTwo = new Product("Peine", 4, 10, warehouse, productState);
            Product productThree = new Product("Zapatillas Adidas", 80, 15, warehouse, productState);


            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            productRepository.Insert(productOne);
            productRepository.Insert(productTwo);
            productRepository.Insert(productThree);
        }

        [Test]
        public void Insert_Test()
        {
            Employee employee = new Employee("AA", "RR", "00", "aa@correo", "Calle AA", "00", "00");
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            WarehouseAdmin warehouseAdmin = new WarehouseAdmin(dateTime, employee);
            Warehouse warehouse = new Warehouse("Calle Tajo", 300, warehouseAdmin);
            ProductState productState = new ProductState("No disponible");
            Product productAdd = new Product("Teclado", 60, 20, warehouse, productState);

            bool correct;
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            correct = productRepository.Insert(productAdd);

            Product productGotten = productRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productGotten.ProductDescription, productAdd.ProductDescription);
            Assert.AreEqual(productGotten.Prize, productAdd.Prize);
            Assert.AreEqual(productGotten.Cuantity, productAdd.Cuantity);
            Assert.AreEqual(productGotten.Warehouse, productAdd.Warehouse);
            Assert.AreEqual(productGotten.ProductState, productAdd.ProductState);

        }

        [Test]
        public void Read_Test()
        {
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);

            Product productGotten = productRepository.Read(3);

            Assert.AreEqual(productGotten.ProductDescription, "Zapatillas Adidas");
            Assert.AreEqual(productGotten.Prize, 80);
            Assert.AreEqual(productGotten.Warehouse.WarehouseAddress, "Calle Ebro");

        }

        [Test]
        public void Update_Test()
        {
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);
            bool correct;
            Product productGotten = productRepository.Read(2);

            productGotten.ProductDescription = "Secador";
            productGotten.Prize = 50;

            correct = productRepository.Update(productGotten);

            Product productCompare = productRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productCompare.ProductDescription, productGotten.ProductDescription);
            Assert.AreEqual(productCompare.Prize, productGotten.Prize);

        }

        [Test]
        public void Delete_Test()
        {
            ProductRepository productRepository = new ProductRepository(dbContext, exceptionController);
            bool correct;
            Product productGotten = productRepository.Read(1);

            correct = productRepository.Delete(productGotten);

            Assert.AreEqual(true, correct);

        }

    }
}
