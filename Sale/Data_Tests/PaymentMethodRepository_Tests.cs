using NUnit.Framework;
using Sale_Data;
using Sale_Data.Context;
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
        private SaleContext dbContext;
        private ExceptionController exceptionController;

        public PaymentMethodRepository_Tests()
        {
            SaleContextProvider.InitializeSaleContext();
            dbContext = SaleContextProvider.GetSaleContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            PaymentMethod paymentMethodOne = new PaymentMethod("Contrarrembolso");
            PaymentMethod paymentMethodTwo = new PaymentMethod("Paypal");
            PaymentMethod paymentMethodThree = new PaymentMethod("VISA");
            PaymentMethodRepository paymentMethodRepository = new PaymentMethodRepository(dbContext, exceptionController);

            paymentMethodRepository.Insert(paymentMethodOne);
            paymentMethodRepository.Insert(paymentMethodTwo);
            paymentMethodRepository.Insert(paymentMethodThree);
        }

        [Test]
        public void Insert_Test()
        {
            PaymentMethod paymentMethodAdd = new PaymentMethod("Cheque");
            bool correct;
            PaymentMethodRepository paymentMethodRepository = new PaymentMethodRepository(dbContext, exceptionController);

            correct = paymentMethodRepository.Insert(paymentMethodAdd);

            PaymentMethod paymentMethodGotten = paymentMethodRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, paymentMethodAdd.PaymentMethodDescription);

        }

        [Test]
        public void Read_Test()
        {
            PaymentMethodRepository paymentMethodRepository = new PaymentMethodRepository(dbContext, exceptionController);

            PaymentMethod paymentMethodGotten = paymentMethodRepository.Read(3);

            Assert.AreEqual(paymentMethodGotten.PaymentMethodDescription, "VISA");

        }

        [Test]
        public void Update_Test()
        {
            PaymentMethodRepository paymentMethodRepository = new PaymentMethodRepository(dbContext, exceptionController);
            bool correct;
            PaymentMethod paymentMethodGotten = paymentMethodRepository.Read(2);

            paymentMethodGotten.PaymentMethodDescription = "Cupon";

            correct = paymentMethodRepository.Update(paymentMethodGotten);

            PaymentMethod paymentMethodCompare = paymentMethodRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(paymentMethodCompare.PaymentMethodDescription, paymentMethodGotten.PaymentMethodDescription);

        }

        [Test]
        public void Delete_Test()
        {
            PaymentMethodRepository paymentMethodRepository = new PaymentMethodRepository(dbContext, exceptionController);
            bool correct;
            PaymentMethod paymentMethodGotten = paymentMethodRepository.Read(1);

            correct = paymentMethodRepository.Delete(paymentMethodGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
