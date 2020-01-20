using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Supplier_Entities.Specific
{
    [DataContract]
    public partial class WarehouseData
    {
        public WarehouseData()
        {

        }

        public WarehouseData(int WarehouseId, string Address, string DNI, string Email)
        {
            this.WarehouseId = WarehouseId;
            this.Address = Address;
            this.DNI = DNI;
            this.Email = Email;
        }

        [DataMember(Name = "warehouseId")]
        public int WarehouseId { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "DNI")]
        public string DNI { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

    }
}
