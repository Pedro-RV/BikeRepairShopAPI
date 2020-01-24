using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Entities.Specific
{
    [DataContract]
    public class WarehouseAdminSpecific
    {
        public WarehouseAdminSpecific()
        {

        }

        public WarehouseAdminSpecific(DateTime StartDate, int EmployeeId, int WarehouseId)
        {
            this.StartDate = StartDate;
            this.EmployeeId = EmployeeId;
            this.WarehouseId = WarehouseId;
        }

        [DataMember(Name = "warehouseAdminId")]
        public int WarehouseAdminId { get; set; }

        [DataMember(Name = "employeeId")]
        public int EmployeeId { get; set; }

        [DataMember(Name = "warehouseId")]
        public int WarehouseId { get; set; }

        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }
    }
}
