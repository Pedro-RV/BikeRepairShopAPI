using Autofac;
using NUnit.Framework;
using Sale_Bussiness;
using Sale_Bussiness.Interfaces;
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
        private IBillBussiness billBussiness;
        private IPaymentMethodBussiness paymentMethodBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.billBussiness = scope.Resolve<IBillBussiness>();
            this.paymentMethodBussiness = scope.Resolve<IPaymentMethodBussiness>();

            this.paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            this.paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Paypal"));
            this.paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("VISA"));
            this.paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Cupon"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            this.billBussiness.InsertBill(new BillSpecific(dateTime, 1));
            this.billBussiness.InsertBill(new BillSpecific(dateTime, 2));
            this.billBussiness.InsertBill(new BillSpecific(dateTime, 3));

        }

        [Test]
        public void InsertBill_Test()
        {
            bool correct;
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            correct = this.billBussiness.InsertBill(new BillSpecific(dateTime, 4));

            Bill billGotten = this.billBussiness.ReadBill(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(billGotten.BillDate, dateTime);

        }

        [Test]
        public void ReadBill_Test()
        {
            Bill billGotten = this.billBussiness.ReadBill(1);

            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            Assert.AreEqual(billGotten.BillDate, dateTime);

        }

        [Test]
        public void UpdateBill_Test()
        {
            bool correct;

            DateTime dateTime = new DateTime(2020, 01, 06, 14, 12, 00);
            BillSpecific change = new BillSpecific();
            change.BillId = 2;
            change.BillDate = dateTime;

            correct = this.billBussiness.UpdateBill(change);

            Bill billCompare = this.billBussiness.ReadBill(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(billCompare.BillDate, change.BillDate);

        }

        [Test]
        public void DeleteBill_Test()
        {
            bool correct;

            correct = this.billBussiness.DeleteBill(3);

            Assert.AreEqual(true, correct);

        }
    }
}
