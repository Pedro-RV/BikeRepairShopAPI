using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Supplier_Entities.EntityModel
{
    [DataContract]
    [Table("WarehouseAdmin")]
    public class WarehouseAdmin
    {

        public WarehouseAdmin()
        {

        }

        public WarehouseAdmin(DateTime StartDate, Employee Employee)
        {
            this.StartDate = StartDate;
            this.Employee = Employee;

            if(Employee != null)
            {
                this.EmployeeId = Employee.EmployeeId;
            }
            else
            {
                this.EmployeeId = 0;
            }

        }

        #region Properties

        [DataMember(Name = "warehouseAdminId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseAdminId { get; set; }

        [DataMember(Name = "employeeId")]
        public int EmployeeId { get; set; }

        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }

        #endregion

        #region Foreing keys

        [DataMember(Name = "employee")]
        public Employee Employee { get; set; }

        #endregion
    }
}
