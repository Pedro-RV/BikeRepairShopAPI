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
    class WarehouseAdminBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();
            employeeBussiness.InsertEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();
            warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));

            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();

            warehouseAdminBussiness.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));
            warehouseAdminBussiness.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));
            warehouseAdminBussiness.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));

        }

        [Test]
        public void InsertWarehouseAdmin_Test()
        {
            bool correct;
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);

            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();

            correct = warehouseAdminBussiness.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));

            WarehouseAdmin warehouseAdminGotten = warehouseAdminBussiness.ReadWarehouseAdmin(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseAdminGotten.StartDate, dateTime);

        }


        [Test]
        public void ReadWarehouseAdmin_Test()
        {
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();

            WarehouseAdmin warehouseAdminGotten = warehouseAdminBussiness.ReadWarehouseAdmin(1);

            DateTime seeDateTime = new DateTime(2019, 12, 03, 9, 38, 00);

            Assert.AreEqual(warehouseAdminGotten.StartDate, seeDateTime);

        }

        [Test]
        public void UpdateWarehouseAdmin_Test()
        {
            bool correct;
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();
            DateTime modify = new DateTime(2019, 10, 03, 10, 51, 00);

            WarehouseAdminSpecific change = new WarehouseAdminSpecific();
            change.WarehouseAdminId = 2;
            change.StartDate = modify;

            correct = warehouseAdminBussiness.UpdateWarehouseAdmin(change);

            WarehouseAdmin warehouseAdminCompare = warehouseAdminBussiness.ReadWarehouseAdmin(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseAdminCompare.StartDate, modify);

        }

        [Test]
        public void DeleteWarehouseAdmin_Test()
        {
            bool correct;
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();

            correct = warehouseAdminBussiness.DeleteWarehouseAdmin(3);

            Assert.AreEqual(true, correct);

        }
    }
}
