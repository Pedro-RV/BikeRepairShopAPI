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

        public Sale(int Cuantity, Client Client, Product Product, Bill Bill)
        {
            this.Cuantity = Cuantity;
            this.Client = Client;

            if(Client != null)
            {
                this.ClientId = Client.ClientId;
            }
            else
            {
                this.ClientId = 0;
            }
            
            this.Product = Product;

            if (Product != null)
            {
                this.ProductId = Product.ProductId;
            }
            else
            {
                this.ProductId = 0;
            }
            
            this.Bill = Bill;

            if (Bill != null)
            {
                this.BillId = Bill.BillId;
            }
            else
            {
                this.BillId = 0;
            }
            
        }

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleId { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public int BillId { get; set; }

        public int Cuantity { get; set; }

        #endregion

        #region Foreing keys

        public Client Client { get; set; }

        public Product Product { get; set; }
        
        public Bill Bill { get; set; }

        #endregion
    }
}
