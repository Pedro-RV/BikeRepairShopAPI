using Supplier_Bussiness;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ejemplo2_ConWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/employee/EmployeesList")]
        public List<Employee> EmployeesList()
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();

            List<Employee> request = employeeBussiness.EmployeesList();

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/employee/GetEmployee/{employeeId}")]
        public Employee GetEmployee(int employeeId)
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();

            Employee request = employeeBussiness.ReadEmployee(employeeId);

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/employee/GetEmployeeDNI/{dni}")]
        public Employee GetEmployeeDNI(string dni)
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();

            Employee request = employeeBussiness.ReadEmployeeDNI(dni);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/employee/InsertEmployee")]
        public string InsertEmployee(Employee employeeAdd)
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();

            bool introduced_well = employeeBussiness.InsertEmployee(employeeAdd);

            if(introduced_well == true)
            {
                return "Employee introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Employee could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/employee/UpdateEmployee")]
        public string UpdateEmployee(Employee update)
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();

            bool updated_well = employeeBussiness.UpdateEmployee(update);

            if (updated_well == true)
            {
                return "Employee updated satisfactorily.";
            }
            else
            {
                return "Error !!! Employee could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/employee/DeleteEmployee/{employeeId}")]
        public string DeleteEmployee(int employeeId)
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();

            bool deleted_well = employeeBussiness.DeleteEmployee(employeeId);

            if (deleted_well == true)
            {
                return "Employee deleted satisfactorily.";
            }
            else
            {
                return "Error !!! Employee could not be deleted.";
            }

        }
    }
}
