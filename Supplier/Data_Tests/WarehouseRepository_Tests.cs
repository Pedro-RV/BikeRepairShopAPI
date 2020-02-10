using Autofac;
using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class WarehouseRepository_Tests
    {
        private IWarehouseRepository warehouseRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.warehouseRepository = scope.Resolve<IWarehouseRepository>();

            Warehouse warehouseOne = new Warehouse("Calle Ebro", 120);
            Warehouse warehouseTwo = new Warehouse("Calle Guadalquivir", 200);
            Warehouse warehouseThree = new Warehouse("Calle Genil", 180);

            this.warehouseRepository.Insert(warehouseOne);
            this.warehouseRepository.Insert(warehouseTwo);
            this.warehouseRepository.Insert(warehouseThree);
        }

        [Test]
        public void Insert_Test()
        {
            Warehouse warehouseAdd = new Warehouse("Calle Tajo", 300);

            bool correct;

            correct = this.warehouseRepository.Insert(warehouseAdd);

            Warehouse warehouseGotten = this.warehouseRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseGotten.WarehouseAddress, warehouseAdd.WarehouseAddress);
            Assert.AreEqual(warehouseGotten.Extension, warehouseAdd.Extension);
        }

        [Test]
        public void Read_Test()
        {
            Warehouse warehouseGotten = this.warehouseRepository.Read(3);

            Assert.AreEqual(warehouseGotten.WarehouseAddress, "Calle Genil");
            Assert.AreEqual(warehouseGotten.Extension, 180);
        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            Warehouse warehouseGotten = this.warehouseRepository.Read(2);

            warehouseGotten.WarehouseAddress = "Calle Nilo";
            warehouseGotten.Extension = 1000;

            correct = this.warehouseRepository.Update(warehouseGotten);

            Warehouse warehouseCompare = this.warehouseRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(warehouseCompare.WarehouseAddress, warehouseGotten.WarehouseAddress);
            Assert.AreEqual(warehouseCompare.Extension, warehouseGotten.Extension);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            Warehouse warehouseGotten = this.warehouseRepository.Read(1);

            correct = this.warehouseRepository.Delete(warehouseGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
