using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IEmployeeBussiness
    {
        List<Employee> EmployeesList();

        bool InsertEmployee(string EmployeeName, string Surname, string DNI, string Email, string EmployeeAddress, string CP, string MobileNum);

        Employee ReadEmployee(int EmployeeId);

        Employee ReadEmployeeDNI(string DNI);

        bool UpdateEmployee(Employee update);

        bool DeleteEmployee(int EmployeeId);

    }
}
