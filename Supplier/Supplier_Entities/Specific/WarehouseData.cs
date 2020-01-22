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

        public WarehouseData(int WarehouseId, string WarehouseAddress, EmployeeWarehouseData EmployeeWarehouseData)
        {
            this.WarehouseId = WarehouseId;
            this.WarehouseAddress = WarehouseAddress;
            this.EmployeeWarehouseData = EmployeeWarehouseData;
        }

        [DataMember(Name = "warehouseId")]
        public int WarehouseId { get; set; }

        [DataMember(Name = "warehouseAddress")]
        public string WarehouseAddress { get; set; }

        [DataMember(Name = "employeeWarehouseData")]
        public EmployeeWarehouseData EmployeeWarehouseData;

    }
}
