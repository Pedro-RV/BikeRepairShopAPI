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

        public Sale(double CuantityToPay, int ProductCuantity, int SupplierProductId, Client Client, Bill Bill)
        {           
            this.CuantityToPay = CuantityToPay;

            this.ProductCuantity = ProductCuantity;

            this.SupplierProductId = SupplierProductId;

            this.Client = Client;

            if (Client != null)
            {
                this.ClientId = Client.ClientId;
            }
            else
            {
                this.ClientId = 0;
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

        public int BillId { get; set; }

        public int SupplierProductId { get; set; }

        public double CuantityToPay { get; set; }

        public int ProductCuantity { get; set; }

        #endregion

        #region Foreing keys

        public Client Client { get; set; }
        
        public Bill Bill { get; set; }

        #endregion
    }
}
