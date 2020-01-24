using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Entities.Specific
{
    [DataContract]
    public class WarehouseSpecific
    {
        public WarehouseSpecific()
        {

        }

        public WarehouseSpecific(string WarehouseAddress, int Extension)
        {
            this.WarehouseAddress = WarehouseAddress;
            this.Extension = Extension;
        }

        [DataMember(Name = "warehouseId")]
        public int WarehouseId { get; set; }

        [DataMember(Name = "warehouseAddress")]
        [MaxLength(100)]
        public string WarehouseAddress { get; set; }

        [DataMember(Name = "extension")]
        public int Extension { get; set; }

    }
}
