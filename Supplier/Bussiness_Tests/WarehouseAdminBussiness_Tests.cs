using Autofac;
using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
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
        private IWarehouseBussiness warehouseBussiness;
        private IEmployeeBussiness employeeBussiness;
        private IWarehouseAdminBussiness warehouseAdminBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.warehouseBussiness = scope.Resolve<IWarehouseBussiness>();
            this.employeeBussiness = scope.Resolve<IEmployeeBussiness>();
            this.warehouseAdminBussiness = scope.Resolve<IWarehouseAdminBussiness>();

            this.employeeBussiness.InsertEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);
            this.warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));

            this.warehouseAdminBussiness.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));
            this.warehouseAdminBussiness.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));
            this.warehouseAdminBussiness.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));

        }

        [Test]
        public void InsertWarehouseAdmin_Test()
        {
            bool correct;
            DateTime dateTime = new DateTime(2019, 12, 03, 9, 38, 00);

            correct = this.warehouseAdminBussiness.InsertWarehouseAdmin(new WarehouseAdminSpecific(dateTime, 1, 1));

            WarehouseAdmin warehouseAdminGotten = this.warehouseAdminBussiness.ReadWarehouseAdmin(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseAdminGotten.StartDate, dateTime);

        }


        [Test]
        public void ReadWarehouseAdmin_Test()
        {
            WarehouseAdmin warehouseAdminGotten = this.warehouseAdminBussiness.ReadWarehouseAdmin(1);

            DateTime seeDateTime = new DateTime(2019, 12, 03, 9, 38, 00);

            Assert.AreEqual(warehouseAdminGotten.StartDate, seeDateTime);

        }

        [Test]
        public void UpdateWarehouseAdmin_Test()
        {
            bool correct;
            DateTime modify = new DateTime(2019, 10, 03, 10, 51, 00);

            WarehouseAdminSpecific change = new WarehouseAdminSpecific();
            change.WarehouseAdminId = 2;
            change.StartDate = modify;

            correct = this.warehouseAdminBussiness.UpdateWarehouseAdmin(change);

            WarehouseAdmin warehouseAdminCompare = this.warehouseAdminBussiness.ReadWarehouseAdmin(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseAdminCompare.StartDate, modify);

        }

        [Test]
        public void DeleteWarehouseAdmin_Test()
        {
            bool correct;

            correct = this.warehouseAdminBussiness.DeleteWarehouseAdmin(3);

            Assert.AreEqual(true, correct);

        }
    }
}
