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
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public List<ProductData> Get(int productId)
        {
            //Mocked data
            List<ProductData> data = new List<ProductData>();
            data.Add(new ProductData() 
            {
                ProductId = productId,
                ProductName = "Nombre Mockeado",
                ProductStateName = "Estado Mockeado"
            });

            data.Add(new ProductData()
            {
                ProductId = productId + 1,
                ProductName = "Nombre Mockeado 2",
                ProductStateName = "Estado Mockeado 2"
            });

            return data;

            //EmployeeBussiness employeeBussiness = new EmployeeBussiness();

            //Employee request = employeeBussiness.ReadEmployee(id);

            //return request.EmployeeName;
        }

        // POST api/values
        public void Post([FromBody]ProductData data)
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
