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
    [TestFixture]
    class BillRepository_Tests
    {
        private SaleContext dbContext;
        private ExceptionController exceptionController;

        public BillRepository_Tests()
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
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            Bill billOne = new Bill(dateTime, paymentMethodOne);
            Bill billTwo = new Bill(dateTime, paymentMethodTwo);
            Bill billThree = new Bill(dateTime, paymentMethodThree);
            BillRepository billRepository = new BillRepository(dbContext, exceptionController);
            
            billRepository.Insert(billOne);
            billRepository.Insert(billTwo);
            billRepository.Insert(billThree);
        }

        [Test]
        public void Insert_Test()
        {
            PaymentMethod paymentMethod = new PaymentMethod("Cupon");
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            Bill billAdd = new Bill(dateTime, paymentMethod);
            bool correct;
            BillRepository billRepository = new BillRepository(dbContext, exceptionController);

            correct = billRepository.Insert(billAdd);

            Bill billGotten = billRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(billGotten.BillDate, dateTime);
            Assert.AreEqual(billGotten.PaymentMethod, billAdd.PaymentMethod);

        }

        [Test]
        public void Read_Test()
        {
            BillRepository billRepository = new BillRepository(dbContext, exceptionController);

            Bill billGotten = billRepository.Read(3);

            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);

            Assert.AreEqual(billGotten.BillDate, dateTime);

        }

        [Test]
        public void Update_Test()
        {
            BillRepository billRepository = new BillRepository(dbContext, exceptionController);
            bool correct;
            Bill billGotten = billRepository.Read(2);

            DateTime dateTime = new DateTime(2020, 01, 06, 14, 12, 00);

            billGotten.BillDate = dateTime;

            correct = billRepository.Update(billGotten);

            Bill billCompare = billRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(billCompare.BillDate, billGotten.BillDate);

        }

        [Test]
        public void Delete_Test()
        {
            BillRepository billRepository = new BillRepository(dbContext, exceptionController);
            bool correct;
            Bill billGotten = billRepository.Read(1);

            correct = billRepository.Delete(billGotten);

            Assert.AreEqual(true, correct);

        }

    }
}
