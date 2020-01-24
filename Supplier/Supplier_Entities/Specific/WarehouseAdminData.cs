using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Supplier_Entities.Specific
{
    [DataContract]
    public partial class WarehouseAdminData
    {
        public WarehouseAdminData()
        {

        }

        public WarehouseAdminData(int WarehouseAdminId, DateTime StartDate, int EmployeeId, string EmployeeName, string DNI, 
            int WarehouseId, string WarehouseAddress)
        {
            this.WarehouseAdminId = WarehouseAdminId;
            this.StartDate = StartDate;
            this.EmployeeId = EmployeeId;
            this.EmployeeName = EmployeeName;
            this.DNI = DNI;
            this.WarehouseId = WarehouseId;
            this.WarehouseAddress = WarehouseAddress;
        }

        [DataMember(Name = "warehouseAdminId")]
        public int WarehouseAdminId { get; set; }

        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "employeeId")]
        public int EmployeeId { get; set; }

        [DataMember(Name = "employeeName")]
        public string EmployeeName { get; set; }

        [DataMember(Name = "DNI")]
        public string DNI { get; set; }

        [DataMember(Name = "warehouseId")]
        public int WarehouseId { get; set; }

        [DataMember(Name = "warehouseAddress")]
        public string WarehouseAddress { get; set; }

    }
}
