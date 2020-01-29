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
    class SaleBussiness_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            ClientBussiness clientBussiness = new ClientBussiness();
            clientBussiness.InsertClient(new ClientSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();
            productTypeBussiness.InsertProductType(new ProductTypeSpecific("Ruedas"));
            ProductBussiness productBussiness = new ProductBussiness();
            productBussiness.InsertProduct(new ProductSpecific("Ruedas Michelin", 50, 50, 1));
            PaymentMethodBussiness paymentMethodBussiness = new PaymentMethodBussiness();
            paymentMethodBussiness.InsertPaymentMethod(new PaymentMethodSpecific("Contrarrembolso"));
            DateTime dateTime = new DateTime(2020, 01, 05, 15, 12, 00);
            BillBussiness billBussiness = new BillBussiness();
            billBussiness.InsertBill(new BillSpecific(dateTime, 1));

            SaleBussiness saleBussiness = new SaleBussiness();

            saleBussiness.InsertSale(new SaleSpecific(5, 1, 1, 1));
            saleBussiness.InsertSale(new SaleSpecific(15, 1, 1, 1));
            saleBussiness.InsertSale(new SaleSpecific(20, 1, 1, 1));

        }

        [Test]
        public void InsertSale_Test()
        {
            bool correct;
            SaleBussiness saleBussiness = new SaleBussiness();

            correct = saleBussiness.InsertSale(new SaleSpecific(50, 1, 1, 1));

            Sale saleGotten = saleBussiness.ReadSale(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(saleGotten.Cuantity, 50);

        }

        [Test]
        public void ReadSale_Test()
        {
            SaleBussiness saleBussiness = new SaleBussiness();

            Sale saleGotten = saleBussiness.ReadSale(3);

            Assert.AreEqual(saleGotten.Cuantity, 20);

        }

        [Test]
        public void UpdateSale_Test()
        {
            SaleBussiness saleBussiness = new SaleBussiness();
            bool correct;

            SaleSpecific change = new SaleSpecific();
            change.SaleId = 2;
            change.Cuantity = 22;

            correct = saleBussiness.UpdateSale(change);

            Sale saleCompare = saleBussiness.ReadSale(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(saleCompare.Cuantity, change.Cuantity);

        }

        [Test]
        public void DeleteSale_Test()
        {
            SaleBussiness saleBussiness = new SaleBussiness();
            bool correct;

            correct = saleBussiness.DeleteSale(1);

            Assert.AreEqual(true, correct);

        }
    }
}
