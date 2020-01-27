using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Entities.Specific
{
    public class ProductInfoSpecific
    {
        public ProductInfoSpecific()
        {

        }

        public ProductInfoSpecific(int ProductId, int WarehouseId, int ProductStateId)
        {
            this.ProductId = ProductId;
            this.WarehouseId = WarehouseId;
            this.ProductStateId = ProductStateId;            

        }

        [DataMember(Name = "productInfoId")]
        public int ProductInfoId { get; set; }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "warehouseId")]
        public int WarehouseId { get; set; }

        [DataMember(Name = "productStateId")]
        public int ProductStateId { get; set; }       

    }
}
