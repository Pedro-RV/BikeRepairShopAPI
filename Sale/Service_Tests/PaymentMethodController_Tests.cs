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
    class PaymentMethodController_Tests
    {
        private PaymentMethodController paymentMethodController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.paymentMethodController = scope.Resolve<PaymentMethodController>();

            this.paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            this.paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Paypal"));
            this.paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("VISA"));

        }

        [Test]
        public void InsertPaymentMethod_Test()
        {
            string message = this.paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Cheque"));

            PaymentMethod paymentMethodGotten = this.paymentMethodController.GetPaymentMethod(4);

            Assert.AreEqual(message, "PaymentMethod introduced satisfactorily.");
            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, "Cheque");

        }

        [Test]
        public void GetPaymentMethod_Test()
        {
            PaymentMethod paymentMethodGotten = this.paymentMethodController.GetPaymentMethod(1);

            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, "Contrarrembolso");

        }

        [Test]
        public void UpdatePaymentMethod_Test()
        {
            PaymentMethodSpecific change = new PaymentMethodSpecific();
            change.PaymentMethodId = 2;
            change.PaymentMethodDescription = "Cupon";

            string message = this.paymentMethodController.UpdatePaymentMethod(change);

            PaymentMethod paymentMethodCompare = this.paymentMethodController.GetPaymentMethod(2);

            Assert.AreEqual(message, "PaymentMethod updated satisfactorily.");
            Assert.AreEqual(paymentMethodCompare.PaymentMethodDescription, change.PaymentMethodDescription);

        }

        [Test]
        public void DeletePaymentMethod_Test()
        {
            string message = this.paymentMethodController.DeletePaymentMethod(3);

            Assert.AreEqual(message, "PaymentMethod deleted satisfactorily.");

        }
    }
}
