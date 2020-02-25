using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Entities.Specific
{
    [DataContract]
    public class SaleSpecific
    {
        public SaleSpecific()
        {

        }

        public SaleSpecific(double CuantityToPay, int ProductCuantity, int SupplierProductId, int ClientId, int BillId)
        {
            this.CuantityToPay = CuantityToPay;
            this.ProductCuantity = ProductCuantity;
            this.SupplierProductId = SupplierProductId;
            this.ClientId = ClientId;           
            this.BillId = BillId;

        }

        [DataMember(Name = "saleId")]
        public int SaleId { get; set; }

        [DataMember(Name = "clientId")]
        public int ClientId { get; set; }       

        [DataMember(Name = "billId")]
        public int BillId { get; set; }

        [DataMember(Name = "supplierProductId")]
        public int SupplierProductId { get; set; }
        
        [DataMember(Name = "cuantityToPay")]
        public double CuantityToPay { get; set; }

        [DataMember(Name = "productCuantity")]
        public int ProductCuantity { get; set; }
    }
}
