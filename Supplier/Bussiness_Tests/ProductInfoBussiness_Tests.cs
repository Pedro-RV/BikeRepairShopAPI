//using NUnit.Framework;
//using Supplier_Bussiness;
//using Supplier_Entities.EntityModel;
//using Supplier_Entities.Specific;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bussiness_Tests
//{
//    [TestFixture]
//    class WarehouseProductBussiness_Tests
//    {
//        [TestFixtureSetUp]
//        public void Init()
//        {
//            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();
//            warehouseBussiness.InsertWarehouse(new WarehouseSpecific("Calle Ebro", 120));
//            ProductStateBussiness productStateBussiness = new ProductStateBussiness();
//            productStateBussiness.InsertProductState(new ProductStateSpecific("No disponible"));
//            productStateBussiness.InsertProductState(new ProductStateSpecific("Disponible"));
//            productStateBussiness.InsertProductState(new ProductStateSpecific("Sin existencias"));
//            productStateBussiness.InsertProductState(new ProductStateSpecific("Suspendido"));
//            ProductBussiness productBussiness = new ProductBussiness();
//            productBussiness.InsertProduct(new ProductSpecific("Pelota", 20, 5, true));

//            WarehouseProductBussiness WarehouseProductBussiness = new WarehouseProductBussiness();

//            WarehouseProductBussiness.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 1));
//            WarehouseProductBussiness.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 2));
//            WarehouseProductBussiness.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 3));

//        }

//        [Test]
//        public void InsertWarehouseProduct_Test()
//        {
//            bool correct;
//            WarehouseProductBussiness WarehouseProductBussiness = new WarehouseProductBussiness();
//            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

//            correct = WarehouseProductBussiness.InsertWarehouseProduct(new WarehouseProductSpecific(1, 1, 4));

//            WarehouseProduct WarehouseProductGotten = WarehouseProductBussiness.ReadWarehouseProduct(4);
//            ProductState checkProductState = productStateBussiness.ReadProductState(4);

//            Assert.AreEqual(true, correct);
//            Assert.AreEqual(WarehouseProductGotten.ProductState, checkProductState);

//        }

//        [Test]
//        public void ReadWarehouseProduct_Test()
//        {
//            WarehouseProductBussiness WarehouseProductBussiness = new WarehouseProductBussiness();
//            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

//            WarehouseProduct WarehouseProductGotten = WarehouseProductBussiness.ReadWarehouseProduct(1);
//            ProductState checkProductState = productStateBussiness.ReadProductState(1);

//            Assert.AreEqual(WarehouseProductGotten.ProductState, checkProductState);

//        }

//        [Test]
//        public void UpdateWarehouseProduct_Test()
//        {
//            bool correct;
//            WarehouseProductBussiness WarehouseProductBussiness = new WarehouseProductBussiness();
//            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

//            WarehouseProductSpecific change = new WarehouseProductSpecific();
//            change.WarehouseProductId = 2;
//            change.ProductStateId = 1;

//            correct = WarehouseProductBussiness.UpdateWarehouseProduct(change);

//            WarehouseProduct WarehouseProductGotten = WarehouseProductBussiness.ReadWarehouseProduct(2);
//            ProductState checkProductState = productStateBussiness.ReadProductState(1);

//            Assert.AreEqual(true, correct);
//            Assert.AreEqual(WarehouseProductGotten.ProductState, checkProductState);

//        }

//        [Test]
//        public void DeleteWarehouseProduct_Test()
//        {
//            bool correct;
//            WarehouseProductBussiness WarehouseProductBussiness = new WarehouseProductBussiness();

//            correct = WarehouseProductBussiness.DeleteWarehouseProduct(3);

//            Assert.AreEqual(true, correct);

//        }
//    }
//}
