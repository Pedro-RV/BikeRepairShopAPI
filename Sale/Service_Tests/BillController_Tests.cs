using Autofac;
using NUnit.Framework;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using Sale_Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Tests
{
    [TestFixture]
    class BillController_Tests
    {
        private BillController billController;
        private PaymentMethodController paymentMethodController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.billController = scope.Resolve<BillController>();
            this.paymentMethodController = scope.Resolve<PaymentMethodController>();

            this.paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            this.paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Paypal"));
            this.paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("VISA"));
            this.paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Cupon"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            this.billController.InsertBill(new BillSpecific(dateTime, 1));
            this.billController.InsertBill(new BillSpecific(dateTime, 2));
            this.billController.InsertBill(new BillSpecific(dateTime, 3));

        }

        [Test]
        public void InsertBill_Test()
        {
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            string message = this.billController.InsertBill(new BillSpecific(dateTime, 4));

            Bill billGotten = this.billController.GetBill(4);

            Assert.AreEqual(message, "Bill introduced satisfactorily.");
            Assert.AreEqual(billGotten.BillDate, dateTime);

        }

        [Test]
        public void GetBill_Test()
        {
            Bill billGotten = this.billController.GetBill(1);

            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            Assert.AreEqual(billGotten.BillDate, dateTime);

        }

        [Test]
        public void UpdateBill_Test()
        {
            DateTime dateTime = new DateTime(2020, 01, 06, 14, 12, 00);
            BillSpecific change = new BillSpecific();
            change.BillId = 2;
            change.BillDate = dateTime;

            string message = this.billController.UpdateBill(change);

            Bill billCompare = this.billController.GetBill(2);

            Assert.AreEqual(message, "Bill updated satisfactorily.");
            Assert.AreEqual(billCompare.BillDate, change.BillDate);

        }

        [Test]
        public void DeleteBill_Test()
        {
            string message = this.billController.DeleteBill(3);

            Assert.AreEqual(message, "Bill deleted satisfactorily.");

        }
    }
}
