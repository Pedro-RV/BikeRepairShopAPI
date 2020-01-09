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
    class PaymentMethodRepository_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            PaymentMethod one = new PaymentMethod("Contrarrembolso");
            PaymentMethod two = new PaymentMethod("Paypal");
            PaymentMethod three = new PaymentMethod("VISA");
            PaymentMethodRepository start = new PaymentMethodRepository();

            start.Insert(one);
            start.Insert(two);
            start.Insert(three);
        }

        [Test]
        public void Insert_Test()
        {
            PaymentMethod add = new PaymentMethod("Cheque");
            bool correct;
            PaymentMethodRepository test = new PaymentMethodRepository();

            correct = test.Insert(add);

            PaymentMethod gotten = test.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(gotten.PaymentMethodDescription, add.PaymentMethodDescription);

        }

        [Test]
        public void Read_Test()
        {
            PaymentMethodRepository test = new PaymentMethodRepository();

            PaymentMethod gotten = test.Read(3);

            Assert.AreEqual(gotten.PaymentMethodDescription, "VISA");

        }

        [Test]
        public void Update_Test()
        {
            PaymentMethodRepository test = new PaymentMethodRepository();
            bool correct;
            PaymentMethod gotten = test.Read(2);

            gotten.PaymentMethodDescription = "Cupon";

            correct = test.Update(test.Read(2), gotten);

            PaymentMethod compare = test.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(compare.PaymentMethodDescription, gotten.PaymentMethodDescription);

        }

        [Test]
        public void Delete_Test()
        {
            PaymentMethodRepository test = new PaymentMethodRepository();
            bool correct;
            PaymentMethod gotten = test.Read(1);

            correct = test.Delete(gotten);

            Assert.AreEqual(true, correct);

        }
    }
}
