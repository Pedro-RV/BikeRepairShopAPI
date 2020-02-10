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
    class WarehouseController_Tests
    {
        private WarehouseController warehouseController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.warehouseController = scope.Resolve<WarehouseController>();

            this.warehouseController.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));
            this.warehouseController.InsertWarehouse(new WarehouseSpecific("Calle Guadalquivir", 200));
            this.warehouseController.InsertWarehouse(new WarehouseSpecific("Calle Genil", 180));
            this.warehouseController.InsertWarehouse(new WarehouseSpecific("Avenida Pajaro Carpintero", 150));

        }

        [Test]
        public void AAWarehousesBiggerThanAnExtension_Test()
        {
            List<Warehouse> currentWarehouse = this.warehouseController.WarehousesBiggerThanAnExtensionList(170);

            Assert.AreEqual(currentWarehouse[0].WarehouseAddress, "Calle Guadalquivir");
            Assert.AreEqual(currentWarehouse[1].WarehouseAddress, "Calle Genil");

        }

        [Test]
        public void InsertWarehouse_Test()
        {
            String message = this.warehouseController.InsertWarehouse(new WarehouseSpecific("Calle Tajo", 300));

            Warehouse warehouseGotten = this.warehouseController.GetWarehouse(5);

            Assert.AreEqual(message, "Warehouse introduced satisfactorily.");
            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Tajo");
            Assert.AreEqual(warehouseGotten.Extension, 300);

        }

        [Test]
        public void GetWarehouse_Test()
        {
            Warehouse warehouseGotten = this.warehouseController.GetWarehouse(1);

            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Ebro");
            Assert.AreEqual(warehouseGotten.Extension, 120);

        }

        [Test]
        public void UpdateWarehouse_Test()
        {
            WarehouseSpecific change = new WarehouseSpecific();
            change.WarehouseId = 2;
            change.WarehouseAddress = "Calle Nilo";
            change.Extension = 1000;

            String message = this.warehouseController.UpdateWarehouse(change);

            Warehouse warehouseGotten = this.warehouseController.GetWarehouse(2);

            Assert.AreEqual(message, "Warehouse updated satisfactorily.");
            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Nilo");
            Assert.AreEqual(warehouseGotten.Extension, 1000);

        }

        [Test]
        public void DeleteWarehouse_Test()
        {
            String message = this.warehouseController.DeleteWarehouse(3);

            Assert.AreEqual(message, "Warehouse deleted satisfactorily.");

        }
    }
}
