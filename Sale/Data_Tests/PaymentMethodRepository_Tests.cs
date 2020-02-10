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
    class PaymentMethodRepository_Tests
    {
        private IPaymentMethodRepository paymentMethodRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.paymentMethodRepository = scope.Resolve<IPaymentMethodRepository>();

            PaymentMethod paymentMethodOne = new PaymentMethod("Contrarrembolso");
            PaymentMethod paymentMethodTwo = new PaymentMethod("Paypal");
            PaymentMethod paymentMethodThree = new PaymentMethod("VISA");

            this.paymentMethodRepository.Insert(paymentMethodOne);
            this.paymentMethodRepository.Insert(paymentMethodTwo);
            this.paymentMethodRepository.Insert(paymentMethodThree);
        }

        [Test]
        public void Insert_Test()
        {
            PaymentMethod paymentMethodAdd = new PaymentMethod("Cheque");
            bool correct;

            correct = this.paymentMethodRepository.Insert(paymentMethodAdd);

            PaymentMethod paymentMethodGotten = this.paymentMethodRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, paymentMethodAdd.PaymentMethodDescription);

        }

        [Test]
        public void Read_Test()
        {
            PaymentMethod paymentMethodGotten = this.paymentMethodRepository.Read(1);

            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, "Contrarrembolso");

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            PaymentMethod paymentMethodGotten = this.paymentMethodRepository.Read(2);

            paymentMethodGotten.PaymentMethodDescription = "Cupon";

            correct = this.paymentMethodRepository.Update(paymentMethodGotten);

            PaymentMethod paymentMethodCompare = this.paymentMethodRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(paymentMethodCompare.PaymentMethodDescription, paymentMethodGotten.PaymentMethodDescription);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            PaymentMethod paymentMethodGotten = this.paymentMethodRepository.Read(3);

            correct = this.paymentMethodRepository.Delete(paymentMethodGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
