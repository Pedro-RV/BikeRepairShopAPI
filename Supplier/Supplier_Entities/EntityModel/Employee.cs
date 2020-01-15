using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplier_Entities.EntityModel
{
    [Table("Employee")]
    public class Employee
    {
        public Employee()
        {

        }

        public Employee(string EmployeeName, string Surname, string DNI, string Email, string EmployeeAddress, string CP, string MobileNum)
        {
            this.EmployeeName = EmployeeName;
            this.Surname = Surname;
            this.DNI = DNI;
            this.Email = Email;
            this.EmployeeAddress = EmployeeAddress;
            this.CP = CP;
            this.MobileNum = MobileNum;
        }

        #region Properties

        public int EmployeeId { get; set; }

        [MaxLength(20)]
        public string EmployeeName { get; set; }

        [MaxLength(30)]
        public string Surname { get; set; }

        [MaxLength(15)]
        public string DNI { get; set; }

        [MaxLength(20)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string EmployeeAddress { get; set; }

        [MaxLength(10)]
        public string CP { get; set; }

        [MaxLength(15)]
        public string MobileNum { get; set; }

        #endregion

    }
}
