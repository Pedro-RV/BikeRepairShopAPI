using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InterconnectServicesLibrary.Entities.SupplierSpecific
{
    [DataContract]
    public partial class PurchaseData
    {
        public PurchaseData()
        {

        }

        public PurchaseData(int PurchaseId, DateTime PurchaseDate, int Cuantity, double Prize, int ProductId, string ProductDescription, int SupplyCompanyId, string SupplyCompanyName)
        {
            this.PurchaseId = PurchaseId;
            this.PurchaseDate = PurchaseDate;
            this.Cuantity = Cuantity;
            this.Prize = Prize;
            this.ProductId = ProductId;
            this.ProductDescription = ProductDescription;
            this.SupplyCompanyId = SupplyCompanyId;
            this.SupplyCompanyName = SupplyCompanyName;
        }

        [DataMember(Name = "purchaseId")]
        public int PurchaseId { get; set; }

        [DataMember(Name = "purchaseDate")]
        public DateTime PurchaseDate { get; set; }

        [DataMember(Name = "cuantity")]
        public int Cuantity { get; set; }

        [DataMember(Name = "prize")]
        public double Prize { get; set; }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "productDescription")]
        public string ProductDescription { get; set; }

        [DataMember(Name = "supplyCompanyId")]
        public int SupplyCompanyId { get; set; }

        [DataMember(Name = "supplyCompanyName")]
        public string SupplyCompanyName { get; set; }
    }
}
