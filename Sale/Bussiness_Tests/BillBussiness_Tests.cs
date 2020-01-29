using NUnit.Framework;
using Sale_Bussiness;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Tests
{
    [TestFixture]
    class BillBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            PaymentMethodBussiness paymentMethodBussiness = new PaymentMethodBussiness();
            paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Paypal"));
            paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("VISA"));
            paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Cupon"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            BillBussiness billBussiness = new BillBussiness();

            billBussiness.InsertBill(new BillSpecific(dateTime, 1));
            billBussiness.InsertBill(new BillSpecific(dateTime, 2));
            billBussiness.InsertBill(new BillSpecific(dateTime, 3));

        }

        [Test]
        public void InsertBill_Test()
        {
            bool correct;
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            BillBussiness billBussiness = new BillBussiness();

            correct = billBussiness.InsertBill(new BillSpecific(dateTime, 4));

            Bill billGotten = billBussiness.ReadBill(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(billGotten.BillDate, dateTime);

        }

        [Test]
        public void ReadBill_Test()
        {
            BillBussiness billBussiness = new BillBussiness();

            Bill billGotten = billBussiness.ReadBill(3);

            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            Assert.AreEqual(billGotten.BillDate, dateTime);

        }

        [Test]
        public void UpdateBill_Test()
        {
            BillBussiness billBussiness = new BillBussiness();
            bool correct;

            DateTime dateTime = new DateTime(2020, 01, 06, 14, 12, 00);
            BillSpecific change = new BillSpecific();
            change.BillId = 2;
            change.BillDate = dateTime;

            correct = billBussiness.UpdateBill(change);

            Bill billCompare = billBussiness.ReadBill(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(billCompare.BillDate, change.BillDate);

        }

        [Test]
        public void DeleteBill_Test()
        {
            BillBussiness billBussiness = new BillBussiness();
            bool correct;

            correct = billBussiness.DeleteBill(1);

            Assert.AreEqual(true, correct);

        }
    }
}
