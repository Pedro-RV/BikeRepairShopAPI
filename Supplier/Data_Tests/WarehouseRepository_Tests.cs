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
    class WarehouseRepository_Tests
    {
        private SupplierContext dbContext;
        private ExceptionController exceptionController;

        public WarehouseRepository_Tests()
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

            Warehouse warehouseOne = new Warehouse("Calle Ebro", 120, warehouseAdmin);
            Warehouse warehouseTwo = new Warehouse("Calle Guadalquivir", 200, warehouseAdmin);
            Warehouse warehouseThree = new Warehouse("Calle Genil", 180, warehouseAdmin);


            WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

            warehouseRepository.Insert(warehouseOne);
            warehouseRepository.Insert(warehouseTwo);
            warehouseRepository.Insert(warehouseThree);
        }

        [Test]
        public void Insert_Test()
        {
            Employee employee = new Employee("AA", "RR", "00", "aa@correo", "Calle AA", "00", "00");
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            WarehouseAdmin warehouseAdmin = new WarehouseAdmin(dateTime, employee);
            Warehouse warehouseAdd = new Warehouse("Calle Tajo", 300, warehouseAdmin);

            bool correct;
            WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

            correct = warehouseRepository.Insert(warehouseAdd);

            Warehouse warehouseGotten = warehouseRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseGotten.WarehouseAddress, warehouseAdd.WarehouseAddress);
            Assert.AreEqual(warehouseGotten.Extension, warehouseAdd.Extension);
            Assert.AreEqual(warehouseGotten.WarehouseAdmin, warehouseAdd.WarehouseAdmin);

        }

        [Test]
        public void Read_Test()
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);

            Warehouse warehouseGotten = warehouseRepository.Read(3);

            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Genil");
            Assert.AreEqual(warehouseGotten.Extension, 180);
            Assert.AreEqual(warehouseGotten.WarehouseAdmin.Employee.EmployeeName, "Jacinto");

        }

        [Test]
        public void Update_Test()
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);
            bool correct;
            Warehouse warehouseGotten = warehouseRepository.Read(2);

            warehouseGotten.WarehouseAddress = "Calle Nilo";
            warehouseGotten.Extension = 1000;

            correct = warehouseRepository.Update(warehouseGotten);

            Warehouse warehouseCompare = warehouseRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseCompare.WarehouseAddress, warehouseGotten.WarehouseAddress);
            Assert.AreEqual(warehouseCompare.Extension, warehouseGotten.Extension);

        }

        [Test]
        public void Delete_Test()
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository(dbContext, exceptionController);
            bool correct;
            Warehouse warehouseGotten = warehouseRepository.Read(1);

            correct = warehouseRepository.Delete(warehouseGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
