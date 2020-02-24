using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InterconnectServicesLibrary.Entities.SupplierSpecific
{
    [DataContract]
    public class PurchaseSpecific
    {
        public PurchaseSpecific()
        {

        }

        public PurchaseSpecific(DateTime PurchaseDate, int Cuantity, double Prize, int ProductId, int SupplyCompanyId)
        {
            this.PurchaseDate = PurchaseDate;
            this.Cuantity = Cuantity;
            this.Prize = Prize;
            this.ProductId = ProductId;
            this.SupplyCompanyId = SupplyCompanyId;

        }

        [DataMember(Name = "purchaseId")]
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
    }
}
