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
    [TestFixture]
    class SaleRepository_Tests
    {
        private ISaleRepository saleRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.saleRepository = scope.Resolve<ISaleRepository>();

            Client client = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");            
            PaymentMethod paymentMethod = new PaymentMethod("Contrarrembolso");
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            Bill bill = new Bill(dateTime, paymentMethod);

            Sale saleOne = new Sale(5, 3, 1, client, bill);
            Sale saleTwo = new Sale(15, 2, 1, client, bill);
            Sale saleThree = new Sale(20, 3, 1, client, bill);

            this.saleRepository.Insert(saleOne);
            this.saleRepository.Insert(saleTwo);
            this.saleRepository.Insert(saleThree);
        }

        [Test]
        public void Insert_Test()
        {
            Client client = new Client("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            PaymentMethod paymentMethod = new PaymentMethod("Contrarrembolso");
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            Bill bill = new Bill(dateTime, paymentMethod);

            Sale saleAdd = new Sale(50, 2, 1, client, bill);
            bool correct;

            correct = this.saleRepository.Insert(saleAdd);

            Sale saleGotten = this.saleRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(saleGotten.CuantityToPay, saleAdd.CuantityToPay);
            Assert.AreEqual(saleGotten.ProductCuantity, saleAdd.ProductCuantity);
            Assert.AreEqual(saleGotten.Client, saleAdd.Client);
            Assert.AreEqual(saleGotten.Bill, saleAdd.Bill);

        }

        [Test]
        public void Read_Test()
        {
            Sale saleGotten = this.saleRepository.Read(1);

            Assert.AreEqual(saleGotten.CuantityToPay, 5);

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            Sale saleGotten = this.saleRepository.Read(2);

            saleGotten.CuantityToPay = 22;

            correct = this.saleRepository.Update(saleGotten);

            Sale saleCompare = this.saleRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(saleCompare.CuantityToPay, saleGotten.CuantityToPay);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            Sale saleGotten = this.saleRepository.Read(3);

            correct = this.saleRepository.Delete(saleGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
