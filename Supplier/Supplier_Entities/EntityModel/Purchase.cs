using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Supplier_Entities.EntityModel
{
    [DataContract]
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
            
            if(Product != null)
            {
                this.ProductId = Product.ProductId;
            }
            else
            {
                this.ProductId = 0;
            }

            this.SupplyCompany = SupplyCompany;

            if (SupplyCompany != null)
            {
                this.SupplyCompanyId = SupplyCompany.SupplyCompanyId;
            }
            else
            {
                this.SupplyCompanyId = 0;
            }        
        }

        #region Properties

        [DataMember(Name = "purchaseId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "supplyCompanyId")]
        public int SupplyCompanyId { get; set; }

        [DataMember(Name = "purchaseDate")]
        public DateTime PurchaseDate { get; set; }

        [DataMember(Name = "cuantity")]
        public int Cuantity { get; set; }

        [DataMember(Name = "prize")]
        public double Prize { get; set; }

        #endregion

        #region Foreing keys

        [DataMember(Name = "product")]
        public Product Product { get; set; }

        [DataMember(Name = "supplyCompany")]
        public SupplyCompany SupplyCompany { get; set; }

        #endregion
    }
}
