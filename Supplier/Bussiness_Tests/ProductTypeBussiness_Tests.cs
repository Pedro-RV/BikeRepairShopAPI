﻿using Autofac;
using NUnit.Framework;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Tests
{
    [TestFixture]
    class ProductTypeBussiness_Tests
    {
        private IProductTypeBussiness productTypeBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.productTypeBussiness = scope.Resolve<IProductTypeBussiness>();

            this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ruedas"));
            this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ventiladores"));
            this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Frenos"));

        }

        [Test]
        public void InsertProductType_Test()
        {
            bool correct;

            correct = this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Llantas"));

            ProductType productTypeGotten = this.productTypeBussiness.ReadProductType(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Llantas");

        }

        [Test]
        public void ReadProductType_Test()
        {
            ProductType productTypeGotten = this.productTypeBussiness.ReadProductType(1);

            Assert.AreEqual(productTypeGotten.ProductTypeDescription, "Ruedas");

        }

        [Test]
        public void UpdateProductType_Test()
        {
            bool correct;

            ProductTypeSpecific change = new ProductTypeSpecific();
            change.ProductTypeId = 2;
            change.ProductTypeDescription = "Herramientas";

            correct = this.productTypeBussiness.UpdateProductType(change);

            ProductType productTypeCompare = this.productTypeBussiness.ReadProductType(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(productTypeCompare.ProductTypeDescription, change.ProductTypeDescription);

        }

        [Test]
        public void DeleteProductType_Test()
        {
            bool correct;

            correct = this.productTypeBussiness.DeleteProductType(3);

            Assert.AreEqual(true, correct);

        }
    }
}
