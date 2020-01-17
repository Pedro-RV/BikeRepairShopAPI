using Supplier_Bussiness;
using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Supplier_Service.Controllers
{
    public class ProductStateController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/productState/GetProductState/{productStateId}")]
        public ProductState GetProductState(int productStateId)
        {
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            ProductState request = productStateBussiness.ReadProductState(productStateId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/productState/InsertProductState")]
        public string InsertProductState(ProductState productStateAdd)
        {
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            bool introduced_well = productStateBussiness.InsertProductState(productStateAdd);

            if (introduced_well == true)
            {
                return "ProductState introduced satisfactorily.";
            }
            else
            {
                return "Error !!! ProductState could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/productState/UpdateProductState")]
        public string UpdateProductState(ProductState update)
        {
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            bool updated_well = productStateBussiness.UpdateProductState(update);

            if (updated_well == true)
            {
                return "ProductState updated satisfactorily.";
            }
            else
            {
                return "Error !!! ProductState could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/productState/DeleteProductState/{productStateId}")]
        public string DeleteProductState(int productStateId)
        {
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            bool deleted_well = productStateBussiness.DeleteProductState(productStateId);

            if (deleted_well == true)
            {
                return "ProductState deleted satisfactorily.";
            }
            else
            {
                return "Error !!! ProductState could not be deleted.";
            }

        }
    }
}
