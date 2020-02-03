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
    public class ProductStateController : ApiController
    {
        private IProductStateBussiness productStateBussiness;

        public ProductStateController(IProductStateBussiness productStateBussiness)
        {
            this.productStateBussiness = productStateBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/productState/GetProductState/{productStateId}")]
        public ProductState GetProductState(int productStateId)
        {
            ProductState request = this.productStateBussiness.ReadProductState(productStateId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/productState/InsertProductState")]
        public string InsertProductState(ProductStateSpecific productStateSpecific)
        {
            bool introduced_well = this.productStateBussiness.InsertProductState(productStateSpecific);

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
        public string UpdateProductState(ProductStateSpecific update)
        {
            bool updated_well = this.productStateBussiness.UpdateProductState(update);

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
            bool deleted_well = this.productStateBussiness.DeleteProductState(productStateId);

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
