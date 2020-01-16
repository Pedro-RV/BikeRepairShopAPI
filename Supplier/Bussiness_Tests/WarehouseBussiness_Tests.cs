using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Tests
{
    [TestFixture]
    class WarehouseBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();
            employeeBussiness.InsertEmployee(new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();
            warehouseAdminBussiness.InsertWarehouseAdmin(dateTime, 1);

            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            warehouseBussiness.InsertWarehouse("Calle Ebro", 120, 1);
            warehouseBussiness.InsertWarehouse("Calle Guadalquivir", 200, 1);
            warehouseBussiness.InsertWarehouse("Calle Genil", 180, 1);
            warehouseBussiness.InsertWarehouse("Avenida Pajaro Carpintero", 150, 1);

        }

        [Test]
        public void AAWarehousesBiggerThanAnExtension_Test()
        {
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            List<Warehouse> currentWarehouse = warehouseBussiness.WarehousesBiggerThanAnExtensionList(170);

            Assert.AreEqual(currentWarehouse[0].WarehouseAddress, "Calle Guadalquivir");
            Assert.AreEqual(currentWarehouse[1].WarehouseAddress, "Calle Genil");

        }

        [Test]
        public void InsertWarehouse_Test()
        {
            bool correct;

            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            correct = warehouseBussiness.InsertWarehouse("Calle Tajo", 300, 1);

            Warehouse warehouseGotten = warehouseBussiness.ReadWarehouse(5);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Tajo");
            Assert.AreEqual(warehouseGotten.Extension, 300);

        }

        [Test]
        public void InsertWarehouseAndAdmin_Test()
        {
            bool correct;
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);

            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            correct = warehouseBussiness.InsertWarehouseAndAdmin("Calle Tajo", 300, dateTime, 1);

            Warehouse warehouseGotten = warehouseBussiness.ReadWarehouse(6);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Tajo");
            Assert.AreEqual(warehouseGotten.Extension, 300);

        }

        [Test]
        public void ReadWarehouse_Test()
        {
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            Warehouse warehouseGotten = warehouseBussiness.ReadWarehouse(1);

            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Ebro");
            Assert.AreEqual(warehouseGotten.Extension, 120);

        }

        [Test]
        public void UpdateWarehouse_Test()
        {
            bool correct;
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            Warehouse change = warehouseBussiness.ReadWarehouse(2);
            change.WarehouseAddress = "Calle Nilo";
            change.Extension = 1000;

            correct = warehouseBussiness.UpdateWarehouse(change);

            Warehouse warehouseGotten = warehouseBussiness.ReadWarehouse(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Nilo");
            Assert.AreEqual(warehouseGotten.Extension, 1000);

        }

        [Test]
        public void DeleteWarehouse_Test()
        {
            bool correct;
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            correct = warehouseBussiness.DeleteWarehouse(3);

            Assert.AreEqual(true, correct);

        }
    }
}
