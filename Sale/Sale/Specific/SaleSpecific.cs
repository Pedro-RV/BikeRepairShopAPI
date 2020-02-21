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

        public SaleSpecific(int Cuantity, int SupplierProductId, int ClientId, int BillId)
        {
            this.Cuantity = Cuantity;
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

        [DataMember(Name = "cuantity")]
        public int Cuantity { get; set; }
    }
}
