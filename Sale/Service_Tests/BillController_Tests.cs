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
        [TestFixtureSetUp]
        public void Init()
        {
            PaymentMethodController paymentMethodController = new PaymentMethodController();
            paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Paypal"));
            paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("VISA"));
            paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Cupon"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            BillController billController = new BillController();

            billController.InsertBill(new BillSpecific(dateTime, 1));
            billController.InsertBill(new BillSpecific(dateTime, 2));
            billController.InsertBill(new BillSpecific(dateTime, 3));

        }

        [Test]
        public void InsertBill_Test()
        {
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            BillController billController = new BillController();

            string message = billController.InsertBill(new BillSpecific(dateTime, 4));

            Bill billGotten = billController.GetBill(4);

            Assert.AreEqual(message, "Bill introduced satisfactorily.");
            Assert.AreEqual(billGotten.BillDate, dateTime);

        }

        [Test]
        public void GetBill_Test()
        {
            BillController billController = new BillController();

            Bill billGotten = billController.GetBill(3);

            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            Assert.AreEqual(billGotten.BillDate, dateTime);

        }

        [Test]
        public void UpdateBill_Test()
        {
            BillController billController = new BillController();

            DateTime dateTime = new DateTime(2020, 01, 06, 14, 12, 00);
            BillSpecific change = new BillSpecific();
            change.BillId = 2;
            change.BillDate = dateTime;

            string message = billController.UpdateBill(change);

            Bill billCompare = billController.GetBill(2);

            Assert.AreEqual(message, "Bill updated satisfactorily.");
            Assert.AreEqual(billCompare.BillDate, change.BillDate);

        }

        [Test]
        public void DeleteBill_Test()
        {
            BillController billController = new BillController();

            string message = billController.DeleteBill(1);

            Assert.AreEqual(message, "Bill deleted satisfactorily.");

        }
    }
}
