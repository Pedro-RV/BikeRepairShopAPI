using NUnit.Framework;
using Supplier_Entities.EntityModel;
using Supplier_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tests
{
    [TestFixture]
    class WarehouseController_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            EmployeeController employeeController = new EmployeeController();
            employeeController.InsertEmployee(new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            WarehouseAdminController warehouseAdminController = new WarehouseAdminController();
            warehouseAdminController.InsertWarehouseAdmin(new WarehouseAdmin(dateTime, employeeController.GetEmployee(1)));

            WarehouseController warehouseController = new WarehouseController();

            warehouseController.InsertWarehouse(new Warehouse("Calle Ebro", 120, warehouseAdminController.GetWarehouseAdmin(1)));
            warehouseController.InsertWarehouse(new Warehouse("Calle Guadalquivir", 200, warehouseAdminController.GetWarehouseAdmin(1)));
            warehouseController.InsertWarehouse(new Warehouse("Calle Genil", 180, warehouseAdminController.GetWarehouseAdmin(1)));
            warehouseController.InsertWarehouse(new Warehouse("Avenida Pajaro Carpintero", 150, warehouseAdminController.GetWarehouseAdmin(1)));

        }

        [Test]
        public void AAWarehousesBiggerThanAnExtension_Test()
        {
            WarehouseController warehouseController = new WarehouseController();

            List<Warehouse> currentWarehouse = warehouseController.WarehousesBiggerThanAnExtensionList(170);

            Assert.AreEqual(currentWarehouse[0].WarehouseAddress, "Calle Guadalquivir");
            Assert.AreEqual(currentWarehouse[1].WarehouseAddress, "Calle Genil");

        }

        [Test]
        public void InsertWarehouse_Test()
        {
            WarehouseController warehouseController = new WarehouseController();
            WarehouseAdminController warehouseAdminController = new WarehouseAdminController();

            String message = warehouseController.InsertWarehouse(new Warehouse("Calle Tajo", 300, warehouseAdminController.GetWarehouseAdmin(1)));

            Warehouse warehouseGotten = warehouseController.GetWarehouse(5);

            Assert.AreEqual(message, "Warehouse introduced satisfactorily.");
            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Tajo");
            Assert.AreEqual(warehouseGotten.Extension, 300);

        }

        [Test]
        public void InsertWarehouseAndAdmin_Test()
        {
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);

            WarehouseController warehouseController = new WarehouseController();
            EmployeeController employeeController = new EmployeeController();

            String message = warehouseController.InsertWarehouseAndAdmin(new WarehouseAdmin(dateTime, employeeController.GetEmployee(1)), new Warehouse("Calle Tajo", 300, null));

            Warehouse warehouseGotten = warehouseController.GetWarehouse(6);

            Assert.AreEqual(message, "WarehouseAdmin and Warehouse introduced satisfactorily.");
            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Tajo");
            Assert.AreEqual(warehouseGotten.Extension, 300);

        }

        [Test]
        public void GetWarehouse_Test()
        {
            WarehouseController warehouseController = new WarehouseController();

            Warehouse warehouseGotten = warehouseController.GetWarehouse(1);

            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Ebro");
            Assert.AreEqual(warehouseGotten.Extension, 120);

        }

        [Test]
        public void UpdateWarehouse_Test()
        {
            WarehouseController warehouseController = new WarehouseController();

            Warehouse change = warehouseController.GetWarehouse(2);
            change.WarehouseAddress = "Calle Nilo";
            change.Extension = 1000;

            String message = warehouseController.UpdateWarehouse(change);

            Warehouse warehouseGotten = warehouseController.GetWarehouse(2);

            Assert.AreEqual(message, "Warehouse updated satisfactorily.");
            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Nilo");
            Assert.AreEqual(warehouseGotten.Extension, 1000);

        }

        [Test]
        public void DeleteWarehouse_Test()
        {
            WarehouseController warehouseController = new WarehouseController();

            String message = warehouseController.DeleteWarehouse(3);

            Assert.AreEqual(message, "Warehouse deleted satisfactorily.");

        }
    }
}
