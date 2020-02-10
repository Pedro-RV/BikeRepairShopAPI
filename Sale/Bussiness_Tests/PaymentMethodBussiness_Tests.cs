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
    class PaymentMethodBussiness_Tests
    {
        private IPaymentMethodBussiness paymentMethodBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.paymentMethodBussiness = scope.Resolve<IPaymentMethodBussiness>();

            this.paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            this.paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Paypal"));
            this.paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("VISA"));

        }

        [Test]
        public void InsertPaymentMethod_Test()
        {
            bool correct;

            correct = this.paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Cheque"));

            PaymentMethod paymentMethodGotten = this.paymentMethodBussiness.ReadPaymentMethod(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, "Cheque");

        }

        [Test]
        public void ReadPaymentMethod_Test()
        {
            PaymentMethod paymentMethodGotten = this.paymentMethodBussiness.ReadPaymentMethod(1);

            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, "Contrarrembolso");

        }

        [Test]
        public void UpdatePaymentMethod_Test()
        {
            bool correct;

            PaymentMethodSpecific change = new PaymentMethodSpecific();
            change.PaymentMethodId = 2;
            change.PaymentMethodDescription = "Cupon";

            correct = this.paymentMethodBussiness.UpdatePaymentMethod(change);

            PaymentMethod paymentMethodCompare = this.paymentMethodBussiness.ReadPaymentMethod(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(paymentMethodCompare.PaymentMethodDescription, change.PaymentMethodDescription);

        }

        [Test]
        public void DeletePaymentMethod_Test()
        {
            bool correct;

            correct = this.paymentMethodBussiness.DeletePaymentMethod(3);

            Assert.AreEqual(true, correct);

        }
    }
}
