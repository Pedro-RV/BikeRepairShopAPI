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
    public class EmployeeSpecific
    {
        public EmployeeSpecific()
        {

        }

        public EmployeeSpecific(string EmployeeName, string Surname, string DNI, string Email, string EmployeeAddress, string CP, string MobileNum)
        {
            this.EmployeeName = EmployeeName;
            this.Surname = Surname;
            this.DNI = DNI;
            this.Email = Email;
            this.EmployeeAddress = EmployeeAddress;
            this.CP = CP;
            this.MobileNum = MobileNum;
        }

        [DataMember(Name = "employeeId")]
        public int EmployeeId { get; set; }

        [DataMember(Name = "employeeName")]
        [MaxLength(20)]
        public string EmployeeName { get; set; }

        [DataMember(Name = "surname")]
        [MaxLength(30)]
        public string Surname { get; set; }

        [DataMember(Name = "dni")]
        [MaxLength(15)]
        public string DNI { get; set; }

        [DataMember(Name = "email")]
        [MaxLength(20)]
        public string Email { get; set; }

        [DataMember(Name = "employeeAddress")]
        [MaxLength(100)]
        public string EmployeeAddress { get; set; }

        [DataMember(Name = "cp")]
        [MaxLength(10)]
        public string CP { get; set; }

        [DataMember(Name = "mobileNum")]
        [MaxLength(15)]
        public string MobileNum { get; set; }

    }
}
