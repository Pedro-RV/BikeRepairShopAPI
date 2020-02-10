using Autofac;
using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
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
        private IWarehouseAdminRepository warehouseAdminRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.warehouseAdminRepository = scope.Resolve<IWarehouseAdminRepository>();

            Employee employee = new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            Warehouse warehouse = new Warehouse("Calle Ebro", 120);
            WarehouseAdmin warehouseAdminOne = new WarehouseAdmin(dateTime, employee, warehouse);
            WarehouseAdmin warehouseAdminTwo = new WarehouseAdmin(dateTime, employee, warehouse);
            WarehouseAdmin warehouseAdminThree = new WarehouseAdmin(dateTime, employee, warehouse);

            this.warehouseAdminRepository.Insert(warehouseAdminOne);
            this.warehouseAdminRepository.Insert(warehouseAdminTwo);
            this.warehouseAdminRepository.Insert(warehouseAdminThree);
        }

        [Test]
        public void Insert_Test()
        {
            Employee employee = new Employee("AA", "RR", "00", "aa@correo", "Calle AA", "00", "00");
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            Warehouse warehouse = new Warehouse("Calle Ebro", 120);
            WarehouseAdmin warehouseAdminAdd = new WarehouseAdmin(dateTime, employee, warehouse);
            bool correct;

            correct = this.warehouseAdminRepository.Insert(warehouseAdminAdd);

            WarehouseAdmin warehouseAdminGotten = this.warehouseAdminRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseAdminGotten.StartDate, warehouseAdminAdd.StartDate);
            Assert.AreEqual(warehouseAdminGotten.Employee, warehouseAdminAdd.Employee);
        }

        [Test]
        public void Read_Test()
        {
            WarehouseAdmin warehouseAdminGotten = this.warehouseAdminRepository.Read(3);

            Assert.AreEqual(warehouseAdminGotten.Employee.EmployeeName, "Jacinto");
            Assert.AreEqual(warehouseAdminGotten.Warehouse.WarehouseAddress, "Calle Ebro");

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            WarehouseAdmin warehouseAdminGotten = this.warehouseAdminRepository.Read(2);
            Employee employee = new Employee("Rodolfo", "Suarez", "11", "rodolf@correo", "Avnd Institucion", "123", "321");

            warehouseAdminGotten.Employee = employee;

            correct = this.warehouseAdminRepository.Update(warehouseAdminGotten);

            WarehouseAdmin warehouseAdminCompare = this.warehouseAdminRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseAdminCompare.Employee, warehouseAdminGotten.Employee);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            WarehouseAdmin warehouseAdminGotten = this.warehouseAdminRepository.Read(1);

            correct = this.warehouseAdminRepository.Delete(warehouseAdminGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
