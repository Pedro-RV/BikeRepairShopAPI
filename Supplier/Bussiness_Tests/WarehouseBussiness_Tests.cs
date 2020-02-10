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
    class WarehouseBussiness_Tests
    {
        private IWarehouseBussiness warehouseBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.warehouseBussiness = scope.Resolve<IWarehouseBussiness>();

            this.warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));
            this.warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Calle Guadalquivir", 200));
            this.warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Calle Genil", 180));
            this.warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Avenida Pajaro Carpintero", 150));

        }

        [Test]
        public void AAWarehousesBiggerThanAnExtension_Test()
        {
            List<Warehouse> currentWarehouse = this.warehouseBussiness.WarehousesBiggerThanAnExtensionList(170);

            Assert.AreEqual(currentWarehouse[0].WarehouseAddress, "Calle Guadalquivir");
            Assert.AreEqual(currentWarehouse[1].WarehouseAddress, "Calle Genil");

        }

        [Test]
        public void InsertWarehouse_Test()
        {
            bool correct;

            correct = this.warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Calle Tajo", 300));

            Warehouse warehouseGotten = this.warehouseBussiness.ReadWarehouse(5);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Tajo");
            Assert.AreEqual(warehouseGotten.Extension, 300);

        }

        [Test]
        public void ReadWarehouse_Test()
        {
            Warehouse warehouseGotten = this.warehouseBussiness.ReadWarehouse(1);

            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Ebro");
            Assert.AreEqual(warehouseGotten.Extension, 120);

        }

        [Test]
        public void UpdateWarehouse_Test()
        {
            bool correct;

            WarehouseSpecific change = new WarehouseSpecific();
            change.WarehouseId = 2;
            change.WarehouseAddress = "Calle Nilo";
            change.Extension = 1000;

            correct = this.warehouseBussiness.UpdateWarehouse(change);

            Warehouse warehouseGotten = this.warehouseBussiness.ReadWarehouse(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Nilo");
            Assert.AreEqual(warehouseGotten.Extension, 1000);

        }

        [Test]
        public void DeleteWarehouse_Test()
        {
            bool correct;

            correct = this.warehouseBussiness.DeleteWarehouse(3);

            Assert.AreEqual(true, correct);

        }
    }
}
