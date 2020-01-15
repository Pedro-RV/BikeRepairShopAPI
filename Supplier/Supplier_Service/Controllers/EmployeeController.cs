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
        // GET api/employee/employeeId
        public string Get([FromBody]string valor)
        {
            return "HOLA";
        }

    }
}
