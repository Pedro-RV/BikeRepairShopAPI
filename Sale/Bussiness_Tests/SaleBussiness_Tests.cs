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
    class SaleBussiness_Tests
    {
        private ISaleBussiness saleBussiness;
        private IProductBussiness productBussiness;
        private IProductTypeBussiness productTypeBussiness;
        private IClientBussiness clientBussiness;
        private IPaymentMethodBussiness paymentMethodBussiness;
        private IBillBussiness billBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.saleBussiness = scope.Resolve<ISaleBussiness>();
            this.productBussiness = scope.Resolve<IProductBussiness>();
            this.productTypeBussiness = scope.Resolve<IProductTypeBussiness>();
            this.clientBussiness = scope.Resolve<IClientBussiness>();
            this.paymentMethodBussiness = scope.Resolve<IPaymentMethodBussiness>();
            this.billBussiness = scope.Resolve<IBillBussiness>();


            this.clientBussiness.InsertClient(new ClientSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            this.productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ruedas"));
            this.productBussiness.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            this.paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            this.billBussiness.InsertBill(new BillSpecific(dateTime, 1));

            this.saleBussiness.InsertSale(new SaleSpecific(5, 1, 1, 1));
            this.saleBussiness.InsertSale(new SaleSpecific(15, 1, 1, 1));
            this.saleBussiness.InsertSale(new SaleSpecific(20, 1, 1, 1));

        }

        [Test]
        public void InsertSale_Test()
        {
            bool correct;

            correct = this.saleBussiness.InsertSale(new SaleSpecific(50, 1, 1, 1));

            Sale saleGotten = this.saleBussiness.ReadSale(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(saleGotten.Cuantity, 50);

        }

        [Test]
        public void ReadSale_Test()
        {
            Sale saleGotten = this.saleBussiness.ReadSale(1);

            Assert.AreEqual(saleGotten.Cuantity, 5);

        }

        [Test]
        public void UpdateSale_Test()
        {
            bool correct;

            SaleSpecific change = new SaleSpecific();
            change.SaleId = 2;
            change.Cuantity = 22;

            correct = this.saleBussiness.UpdateSale(change);

            Sale saleCompare = this.saleBussiness.ReadSale(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(saleCompare.Cuantity, change.Cuantity);

        }

        [Test]
        public void DeleteSale_Test()
        {
            bool correct;

            correct = this.saleBussiness.DeleteSale(3);

            Assert.AreEqual(true, correct);

        }
    }
}
