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
        [TestFixtureSetUp]
        public void Init()
        {
            ClientController clientController = new ClientController();
            clientController.InsertClient(new ClientSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            ProductTypeController productTypeController = new ProductTypeController();
            productTypeController.InsertProductType(new ProductTypeSpecific("Ruedas"));
            ProductController productController = new ProductController();
            productController.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            PaymentMethodController paymentMethodController = new PaymentMethodController();
            paymentMethodController.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            BillController billController = new BillController();
            billController.InsertBill(new BillSpecific(dateTime, 1));

            SaleController saleController = new SaleController();

            saleController.InsertSale(new SaleSpecific(5, 1, 1, 1));
            saleController.InsertSale(new SaleSpecific(15, 1, 1, 1));
            saleController.InsertSale(new SaleSpecific(20, 1, 1, 1));

        }

        [Test]
        public void InsertSale_Test()
        {
            SaleController saleController = new SaleController();

            String message = saleController.InsertSale(new SaleSpecific(50, 1, 1, 1));

            Sale saleGotten = saleController.GetSale(4);

            Assert.AreEqual(message, "Sale introduced satisfactorily.");
            Assert.AreEqual(saleGotten.Cuantity, 50);

        }

        [Test]
        public void GetSale_Test()
        {
            SaleController saleController = new SaleController();

            Sale saleGotten = saleController.GetSale(3);

            Assert.AreEqual(saleGotten.Cuantity, 20);

        }

        [Test]
        public void UpdateSale_Test()
        {
            SaleController saleController = new SaleController();

            SaleSpecific change = new SaleSpecific();
            change.SaleId = 2;
            change.Cuantity = 22;

            String message = saleController.UpdateSale(change);

            Sale saleCompare = saleController.GetSale(2);

            Assert.AreEqual(message, "Sale updated satisfactorily.");
            Assert.AreEqual(saleCompare.Cuantity, change.Cuantity);

        }

        [Test]
        public void DeleteSale_Test()
        {
            SaleController saleController = new SaleController();

            String message = saleController.DeleteSale(1);

            Assert.AreEqual(message, "Sale deleted satisfactorily.");

        }
    }
}
