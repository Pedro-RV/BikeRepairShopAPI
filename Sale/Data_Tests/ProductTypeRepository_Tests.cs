using NUnit.Framework;
using Sale_Data;
using Sale_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class ProductTypeRepository_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            ProductType one = new ProductType("Ruedas");
            ProductType two = new ProductType("Ventiladores");
            ProductType three = new ProductType("Frenos");
            ProductTypeRepository start = new ProductTypeRepository();

            start.Insert(one);
            start.Insert(two);
            start.Insert(three);
        }

        [Test]
        public void Insert_Test()
        {
            ProductType add = new ProductType("Llantas");
            bool correct;
            ProductTypeRepository test = new ProductTypeRepository();

            correct = test.Insert(add);

            ProductType gotten = test.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(gotten.ProductTypeDescription, add.ProductTypeDescription);

        }

        [Test]
        public void Read_Test()
        {
            ProductTypeRepository test = new ProductTypeRepository();

            ProductType gotten = test.Read(3);

            Assert.AreEqual(gotten.ProductTypeDescription, "Frenos");

        }

        [Test]
        public void Update_Test()
        {
            ProductTypeRepository test = new ProductTypeRepository();
            bool correct;
            ProductType gotten = test.Read(2);

            gotten.ProductTypeDescription = "Herramientas";

            correct = test.Update(test.Read(2), gotten);

            ProductType compare = test.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(compare.ProductTypeDescription, gotten.ProductTypeDescription);

        }

        [Test]
        public void Delete_Test()
        {
            ProductTypeRepository test = new ProductTypeRepository();
            bool correct;
            ProductType gotten = test.Read(1);

            correct = test.Delete(gotten);

            Assert.AreEqual(true, correct);

        }
    }
}
