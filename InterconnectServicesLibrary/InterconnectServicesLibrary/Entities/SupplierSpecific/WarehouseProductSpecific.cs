using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InterconnectServicesLibrary.Entities.SupplierSpecific
{
    public class WarehouseProductSpecific
    {
        public WarehouseProductSpecific()
        {

        }

        public WarehouseProductSpecific(int ProductId, int WarehouseId, int ProductStateId)
        {
            this.ProductId = ProductId;
            this.WarehouseId = WarehouseId;
            this.ProductStateId = ProductStateId;

        }

        [DataMember(Name = "warehouseProductId")]
        public int WarehouseProductId { get; set; }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "warehouseId")]
        public int WarehouseId { get; set; }

        [DataMember(Name = "productStateId")]
        public int ProductStateId { get; set; }

    }
}
