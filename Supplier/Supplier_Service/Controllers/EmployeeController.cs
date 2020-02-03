using Autofac;
using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Supplier_Service.Controllers
{
    public class EmployeeController : ApiController
    {

        private IEmployeeBussiness employeeBussiness;

        public EmployeeController(IEmployeeBussiness employeeBussiness)
        {
            this.employeeBussiness = employeeBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/employee/EmployeesList")]
        public List<Employee> EmployeesList()
        {
            List<Employee> request = this.employeeBussiness.EmployeesList();

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/employee/GetEmployee/{employeeId}")]
        public Employee GetEmployee(int employeeId)
        {
            Employee request = this.employeeBussiness.ReadEmployee(employeeId);

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/employee/GetEmployeeDNI/{dni}")]
        public Employee GetEmployeeDNI(string dni)
        {
            Employee request = this.employeeBussiness.ReadEmployeeDNI(dni);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/employee/InsertEmployee")]
        public string InsertEmployee(EmployeeSpecific employeeSpecific)
        {
            bool introduced_well = this.employeeBussiness.InsertEmployee(employeeSpecific);

            if (introduced_well == true)
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
        public string UpdateEmployee(EmployeeSpecific update)
        {
            bool updated_well = this.employeeBussiness.UpdateEmployee(update);

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
            bool deleted_well = this.employeeBussiness.DeleteEmployee(employeeId);

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
