using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Supplier_Entities.Specific
{
    [DataContract]
    public partial class EmployeeWarehouseData
    {
        public EmployeeWarehouseData()
        {

        }

        public EmployeeWarehouseData(string DNI, string Email)
        {
            this.DNI = DNI;
            this.Email = Email;
        }

        [DataMember(Name = "dni")]
        public string DNI { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}
