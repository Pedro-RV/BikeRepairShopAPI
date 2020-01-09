using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> EmployeesList();

        bool Insert(Employee add);

        Employee Read(int EmployeeId);

        Employee ReadDNI(string DNI);

        bool Update(Employee update);

        bool Delete(Employee del);
    }
}
