using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplier_Entities.EntityModel
{
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseAdminId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime StartDate { get; set; }

        #endregion

        #region Foreing keys

        public Employee Employee { get; set; }

        #endregion
    }
}
