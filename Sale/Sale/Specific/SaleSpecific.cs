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

        public SaleSpecific(int Cuantity, int ClientId, int ProductId, int BillId)
        {
            this.Cuantity = Cuantity;
            this.ClientId = ClientId;
            this.ProductId = ProductId;
            this.BillId = BillId;

        }

        [DataMember(Name = "saleId")]
        public int SaleId { get; set; }

        [DataMember(Name = "clientId")]
        public int ClientId { get; set; }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "billId")]
        public int BillId { get; set; }

        [DataMember(Name = "cuantity")]
        public int Cuantity { get; set; }
    }
}
