using Sale_Bussiness;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sale_Service.Controllers
{
    public class ProductTypeController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/productType/GetProductType/{productTypeId}")]
        public ProductType GetProductType(int productTypeId)
        {
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();

            ProductType request = productTypeBussiness.ReadProductType(productTypeId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/productType/InsertProductType")]
        public string InsertProductType(ProductTypeSpecific productTypeSpecific)
        {
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();

            bool introduced_well = productTypeBussiness.InsertProductType(productTypeSpecific);

            if (introduced_well == true)
            {
                return "ProductType introduced satisfactorily.";
            }
            else
            {
                return "Error !!! ProductType could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/productType/UpdateProductType")]
        public string UpdateProductType(ProductTypeSpecific update)
        {
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();

            bool updated_well = productTypeBussiness.UpdateProductType(update);

            if (updated_well == true)
            {
                return "ProductType updated satisfactorily.";
            }
            else
            {
                return "Error !!! ProductType could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/productType/DeleteProductType/{productTypeId}")]
        public string DeleteProductType(int productTypeId)
        {
            ProductTypeBussiness productTypeBussiness = new ProductTypeBussiness();

            bool deleted_well = productTypeBussiness.DeleteProductType(productTypeId);

            if (deleted_well == true)
            {
                return "ProductType deleted satisfactorily.";
            }
            else
            {
                return "Error !!! ProductType could not be deleted.";
            }

        }
    }
}
