using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplier_Entities.EntityModel
{
    [Table("Purchase")]
    public class Purchase
    {
        public Purchase()
        {

        }

        public Purchase(DateTime PurchaseDate, int Cuantity, double Prize, Product Product, SupplyCompany SupplyCompany)
        {
            this.PurchaseDate = PurchaseDate;
            this.Cuantity = Cuantity;
            this.Prize = Prize;
            this.Product = Product;
            this.SupplyCompany = SupplyCompany;
            this.ProductId = Product.ProductId;
            this.SupplyCompanyId = SupplyCompany.SupplyCompanyId;
        }

        #region Properties

        public int PurchaseId { get; set; }

        public int ProductId { get; set; }

        public int SupplyCompanyId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int Cuantity { get; set; }

        public double Prize { get; set; }

        #endregion

        #region Foreing keys

        public Product Product { get; set; }

        public SupplyCompany SupplyCompany { get; set; }

        #endregion
    }
}
