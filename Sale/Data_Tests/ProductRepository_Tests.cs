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
    class ProductRepository_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            ProductType aux = new ProductType("Ruedas");
            Product one = new Product("Ruedas Michelin", 50, 50, aux);
            Product two = new Product("Ruedas Tractor", 200, 25, aux);
            Product three = new Product("Ruedas Grua", 350, 20, aux);
            ProductRepository start = new ProductRepository();

            start.Insert(one);
            start.Insert(two);
            start.Insert(three);
        }

        [Test]
        public void Insert_Test()
        {
            ProductType aux = new ProductType("Ruedas");
            Product add = new Product("Ruedas Armilla", 45, 60, aux);
            bool correct;
            ProductRepository test = new ProductRepository();

            correct = test.Insert(add);

            Product gotten = test.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(gotten.ProductDescription, add.ProductDescription);
            Assert.AreEqual(gotten.Prize, add.Prize);
            Assert.AreEqual(gotten.Cuantity, add.Cuantity);
            Assert.AreEqual(gotten.ProductType, add.ProductType);

        }

        [Test]
        public void Read_Test()
        {
            ProductRepository test = new ProductRepository();

            Product gotten = test.Read(3);

            Assert.AreEqual(gotten.ProductDescription, "Ruedas Grua");
            Assert.AreEqual(gotten.Prize, 350);
            Assert.AreEqual(gotten.Cuantity, 20);

        }

        [Test]
        public void Update_Test()
        {
            ProductRepository test = new ProductRepository();
            bool correct;
            Product gotten = test.Read(2);

            gotten.ProductDescription = "Ruedas China";
            gotten.Prize = 25;

            correct = test.Update(test.Read(2), gotten);

            Product compare = test.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(compare.ProductDescription, gotten.ProductDescription);
            Assert.AreEqual(compare.Prize, gotten.Prize);

        }

        [Test]
        public void Delete_Test()
        {
            ProductRepository test = new ProductRepository();
            bool correct;
            Product gotten = test.Read(1);

            correct = test.Delete(gotten);

            Assert.AreEqual(true, correct);

        }
    }
}
