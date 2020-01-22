using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Supplier_Entities.Specific
{
    [DataContract]
    public partial class WarehouseData_Aux
    {
        public WarehouseData_Aux()
        {

        }

        public WarehouseData_Aux(int WarehouseId, string WarehouseAddress, string DNI, string Email)
        {
            this.WarehouseId = WarehouseId;
            this.WarehouseAddress = WarehouseAddress;
            this.DNI = DNI;
            this.Email = Email;
        }

        [DataMember(Name = "warehouseId")]
        public int WarehouseId { get; set; }

        [DataMember(Name = "warehouseAddress")]
        public string WarehouseAddress { get; set; }

        [DataMember(Name = "dni")]
        public string DNI { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}
