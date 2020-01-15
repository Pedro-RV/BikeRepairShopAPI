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
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public Employee Get(int employeeId)
        {
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();

            Employee request = employeeBussiness.ReadEmployee(employeeId);

            return request;
        }

        // POST api/values
        public void Post(Employee employee)
        {
            //Guardar datos
        }

        // PUT api/values/5
        public void Put([FromBody]int id)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
