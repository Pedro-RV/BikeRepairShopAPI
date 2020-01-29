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
    class PaymentMethodBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            PaymentMethodBussiness paymentMethodBussiness = new PaymentMethodBussiness();

            paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Paypal"));
            paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("VISA"));

        }

        [Test]
        public void InsertPaymentMethod_Test()
        {
            bool correct;
            PaymentMethodBussiness paymentMethodBussiness = new PaymentMethodBussiness();

            correct = paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Cheque"));

            PaymentMethod paymentMethodGotten = paymentMethodBussiness.ReadPaymentMethod(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, "Cheque");

        }

        [Test]
        public void ReadPaymentMethod_Test()
        {
            PaymentMethodBussiness paymentMethodBussiness = new PaymentMethodBussiness();

            PaymentMethod paymentMethodGotten = paymentMethodBussiness.ReadPaymentMethod(3);

            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, "VISA");

        }

        [Test]
        public void UpdatePaymentMethod_Test()
        {
            PaymentMethodBussiness paymentMethodBussiness = new PaymentMethodBussiness();
            bool correct;

            PaymentMethodSpecific change = new PaymentMethodSpecific();
            change.PaymentMethodId = 2;
            change.PaymentMethodDescription = "Cupon";

            correct = paymentMethodBussiness.UpdatePaymentMethod(change);

            PaymentMethod paymentMethodCompare = paymentMethodBussiness.ReadPaymentMethod(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(paymentMethodCompare.PaymentMethodDescription, change.PaymentMethodDescription);

        }

        [Test]
        public void DeletePaymentMethod_Test()
        {
            PaymentMethodBussiness paymentMethodBussiness = new PaymentMethodBussiness();
            bool correct;

            correct = paymentMethodBussiness.DeletePaymentMethod(1);

            Assert.AreEqual(true, correct);

        }
    }
}
