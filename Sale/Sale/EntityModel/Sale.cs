using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sale_Entities.EntityModel
{
    [Table("Sale")]
    public class Sale
    {
        public Sale()
        {

        }

        public Sale(DateTime SaleDate, int Cuantity, Client Client, Product Product, PaymentMethod PaymentMethod)
        {
            this.SaleDate = SaleDate;
            this.Cuantity = Cuantity;
            this.Client = Client;
            this.ClientId = Client.ClientId;
            this.Product = Product;
            this.ProductId = Product.ProductId;
            this.PaymentMethod = PaymentMethod;
            this.PaymentMethodId = PaymentMethod.PaymentMethodId;
        }

        #region Properties

        public int SaleId { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public int PaymentMethodId { get; set; }

        public DateTime SaleDate { get; set; }

        public int Cuantity { get; set; }

        #endregion

        #region Foreing keys

        public Client Client { get; set; }

        public Product Product { get; set; }
        
        public PaymentMethod PaymentMethod { get; set; }

        #endregion
    }
}
