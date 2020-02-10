using Autofac;
using NUnit.Framework;
using Sale_Data;
using Sale_Data.Context;
using Sale_Data.Interfaces;
using Sale_Entities.EntityModel;
using Sale_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tests
{
    [TestFixture]
    class BillRepository_Tests
    {
        private IBillRepository billRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.billRepository = scope.Resolve<IBillRepository>();

            PaymentMethod paymentMethodOne = new PaymentMethod("Contrarrembolso");
            PaymentMethod paymentMethodTwo = new PaymentMethod("Paypal");
            PaymentMethod paymentMethodThree = new PaymentMethod("VISA");
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            Bill billOne = new Bill(dateTime, paymentMethodOne);
            Bill billTwo = new Bill(dateTime, paymentMethodTwo);
            Bill billThree = new Bill(dateTime, paymentMethodThree);

            this.billRepository.Insert(billOne);
            this.billRepository.Insert(billTwo);
            this.billRepository.Insert(billThree);
        }

        [Test]
        public void Insert_Test()
        {
            PaymentMethod paymentMethod = new PaymentMethod("Cupon");
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            Bill billAdd = new Bill(dateTime, paymentMethod);
            bool correct;

            correct = this.billRepository.Insert(billAdd);

            Bill billGotten = this.billRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(billGotten.BillDate, dateTime);
            Assert.AreEqual(billGotten.PaymentMethod, billAdd.PaymentMethod);

        }

        [Test]
        public void Read_Test()
        {
            Bill billGotten = this.billRepository.Read(3);

            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            Assert.AreEqual(billGotten.BillDate, dateTime);

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            Bill billGotten = this.billRepository.Read(2);

            DateTime dateTime = new DateTime(2020, 01, 06, 14, 12, 00);

            billGotten.BillDate = dateTime;

            correct = this.billRepository.Update(billGotten);

            Bill billCompare = this.billRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(billCompare.BillDate, billGotten.BillDate);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            Bill billGotten = this.billRepository.Read(1);

            correct = this.billRepository.Delete(billGotten);

            Assert.AreEqual(true, correct);

        }

    }
}
