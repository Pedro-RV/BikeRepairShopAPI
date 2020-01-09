using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class WarehouseAdminRepository_Tests
    {
        private SupplierContext dbContext;
        private ExceptionController exceptionController;

        public WarehouseAdminRepository_Tests()
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
            WarehouseAdmin warehouseAdminOne = new WarehouseAdmin(dateTime, employee);
            WarehouseAdmin warehouseAdminTwo = new WarehouseAdmin(dateTime, employee);
            WarehouseAdmin warehouseAdminThree = new WarehouseAdmin(dateTime, employee);

            WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

            warehouseAdminRepository.Insert(warehouseAdminOne);
            warehouseAdminRepository.Insert(warehouseAdminTwo);
            warehouseAdminRepository.Insert(warehouseAdminThree);
        }

        [Test]
        public void Insert_Test()
        {
            Employee employee = new Employee("AA", "RR", "00", "aa@correo", "Calle AA", "00", "00");
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            WarehouseAdmin warehouseAdminAdd = new WarehouseAdmin(dateTime, employee);
            bool correct;
            WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

            correct = warehouseAdminRepository.Insert(warehouseAdminAdd);

            WarehouseAdmin warehouseAdminGotten = warehouseAdminRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseAdminGotten.StartDate, warehouseAdminAdd.StartDate);
            Assert.AreEqual(warehouseAdminGotten.Employee, warehouseAdminAdd.Employee);

        }

        [Test]
        public void Read_Test()
        {
            WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);

            WarehouseAdmin warehouseAdminGotten = warehouseAdminRepository.Read(3);

            Assert.AreEqual(warehouseAdminGotten.Employee.EmployeeName, "Jacinto");

        }

        [Test]
        public void Update_Test()
        {
            WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);
            bool correct;
            WarehouseAdmin warehouseAdminGotten = warehouseAdminRepository.Read(2);
            Employee employee = new Employee("Rodolfo", "Suarez", "11", "rodolf@correo", "Avnd Institucion", "123", "321");

            warehouseAdminGotten.Employee = employee;

            correct = warehouseAdminRepository.Update(warehouseAdminGotten);

            WarehouseAdmin warehouseAdminCompare = warehouseAdminRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseAdminCompare.Employee, warehouseAdminGotten.Employee);

        }

        [Test]
        public void Delete_Test()
        {
            WarehouseAdminRepository warehouseAdminRepository = new WarehouseAdminRepository(dbContext, exceptionController);
            bool correct;
            WarehouseAdmin warehouseAdminGotten = warehouseAdminRepository.Read(1);

            correct = warehouseAdminRepository.Delete(warehouseAdminGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
