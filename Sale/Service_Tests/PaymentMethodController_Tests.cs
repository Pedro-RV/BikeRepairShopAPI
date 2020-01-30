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
    class PaymentMethodController_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            PaymentMethodController paymentMethodController = new PaymentMethodController();

            paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Paypal"));
            paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("VISA"));

        }

        [Test]
        public void InsertPaymentMethod_Test()
        {
            PaymentMethodController paymentMethodController = new PaymentMethodController();

            String message = paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Cheque"));

            PaymentMethod paymentMethodGotten = paymentMethodController.GetPaymentMethod(4);

            Assert.AreEqual(message, "PaymentMethod introduced satisfactorily.");
            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, "Cheque");

        }

        [Test]
        public void GetPaymentMethod_Test()
        {
            PaymentMethodController paymentMethodController = new PaymentMethodController();

            PaymentMethod paymentMethodGotten = paymentMethodController.GetPaymentMethod(3);

            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, "VISA");

        }

        [Test]
        public void UpdatePaymentMethod_Test()
        {
            PaymentMethodController paymentMethodController = new PaymentMethodController();

            PaymentMethodSpecific change = new PaymentMethodSpecific();
            change.PaymentMethodId = 2;
            change.PaymentMethodDescription = "Cupon";

            String message = paymentMethodController.UpdatePaymentMethod(change);

            PaymentMethod paymentMethodCompare = paymentMethodController.GetPaymentMethod(2);

            Assert.AreEqual(message, "PaymentMethod updated satisfactorily.");
            Assert.AreEqual(paymentMethodCompare.PaymentMethodDescription, change.PaymentMethodDescription);

        }

        [Test]
        public void DeletePaymentMethod_Test()
        {
            PaymentMethodController paymentMethodController = new PaymentMethodController();

            String message = paymentMethodController.DeletePaymentMethod(1);

            Assert.AreEqual(message, "PaymentMethod deleted satisfactorily.");

        }
    }
}
