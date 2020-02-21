using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tests
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
        public string EmployeeName { get; set; }

        [DataMember(Name = "surname")]
        public string Surname { get; set; }

        [DataMember(Name = "dni")]
        public string DNI { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "employeeAddress")]
        public string EmployeeAddress { get; set; }

        [DataMember(Name = "cp")]
        public string CP { get; set; }

        [DataMember(Name = "mobileNum")]
        public string MobileNum { get; set; }

    }
}
