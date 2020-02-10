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
    class SaleController_Tests
    {
        private SaleController saleController;
        private ProductController productController;
        private ProductTypeController productTypeController;
        private BillController billController;
        private PaymentMethodController paymentMethodController;
        private ClientController clientController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.saleController = scope.Resolve<SaleController>();
            this.billController = scope.Resolve<BillController>();
            this.paymentMethodController = scope.Resolve<PaymentMethodController>();
            this.productController = scope.Resolve<ProductController>();
            this.productTypeController = scope.Resolve<ProductTypeController>();
            this.clientController = scope.Resolve<ClientController>();

            this.clientController.InsertClient(new ClientSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            this.productTypeController.InsertProductType(new ProductTypeSpecific("Ruedas"));
            this.productController.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            this.paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            this.billController.InsertBill(new BillSpecific(dateTime, 1));

            this.saleController.InsertSale(new SaleSpecific(5, 1, 1, 1));
            this.saleController.InsertSale(new SaleSpecific(15, 1, 1, 1));
            this.saleController.InsertSale(new SaleSpecific(20, 1, 1, 1));

        }

        [Test]
        public void InsertSale_Test()
        {
            string message = this.saleController.InsertSale(new SaleSpecific(50, 1, 1, 1));

            Sale saleGotten = this.saleController.GetSale(4);

            Assert.AreEqual(message, "Sale introduced satisfactorily.");
            Assert.AreEqual(saleGotten.Cuantity, 50);

        }

        [Test]
        public void GetSale_Test()
        {
            Sale saleGotten = this.saleController.GetSale(1);

            Assert.AreEqual(saleGotten.Cuantity, 5);

        }

        [Test]
        public void UpdateSale_Test()
        {
            SaleSpecific change = new SaleSpecific();
            change.SaleId = 2;
            change.Cuantity = 22;

            string message = this.saleController.UpdateSale(change);

            Sale saleCompare = this.saleController.GetSale(2);

            Assert.AreEqual(message, "Sale updated satisfactorily.");
            Assert.AreEqual(saleCompare.Cuantity, change.Cuantity);

        }

        [Test]
        public void DeleteSale_Test()
        {
            string message = this.saleController.DeleteSale(3);

            Assert.AreEqual(message, "Sale deleted satisfactorily.");

        }
    }
}
