using Autofac;
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
    class WarehouseAdminController_Tests
    {
        private EmployeeController employeeController;
        private WarehouseController warehouseController;
        private WarehouseAdminController warehouseAdminController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.employeeController = scope.Resolve<EmployeeController>();
            this.warehouseController = scope.Resolve<WarehouseController>();
            this.warehouseAdminController = scope.Resolve<WarehouseAdminController>();

            this.employeeController.InsertEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            this.warehouseController.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));

            this.warehouseAdminController.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));
            this.warehouseAdminController.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));
            this.warehouseAdminController.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));

        }

        [Test]
        public void InsertWarehouseAdmin_Test()
        {
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);

            string message = this.warehouseAdminController.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));

            WarehouseAdmin warehouseAdminGotten = this.warehouseAdminController.GetWarehouseAdmin(4);

            Assert.AreEqual(message, "WarehouseAdmin introduced satisfactorily.");
            Assert.AreEqual(warehouseAdminGotten.StartDate, dateTime);

        }

        [Test]
        public void GetWarehouseAdmin_Test()
        {
            WarehouseAdmin warehouseAdminGotten = this.warehouseAdminController.GetWarehouseAdmin(1);

            DateTime seeDateTime = new DateTime(2019, 12, 03, 9, 38, 00);

            Assert.AreEqual(warehouseAdminGotten.StartDate, seeDateTime);

        }

        [Test]
        public void UpdateWarehouseAdmin_Test()
        {
            DateTime modify = new DateTime(2019, 10, 03, 10, 51, 00);

            WarehouseAdminSpecific change = new WarehouseAdminSpecific();
            change.WarehouseAdminId = 2;
            change.StartDate = modify;

            string message = this.warehouseAdminController.UpdateWarehouseAdmin(change);

            WarehouseAdmin warehouseAdminCompare = this.warehouseAdminController.GetWarehouseAdmin(2);

            Assert.AreEqual(message, "WarehouseAdmin updated satisfactorily.");
            Assert.AreEqual(warehouseAdminCompare.StartDate, modify);

        }

        [Test]
        public void DeleteWarehouseAdmin_Test()
        {
            string message = this.warehouseAdminController.DeleteWarehouseAdmin(3);

            Assert.AreEqual(message, "WarehouseAdmin deleted satisfactorily.");

        }
    }
}
