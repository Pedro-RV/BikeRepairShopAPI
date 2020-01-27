using Supplier_Bussiness;
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
    public class ProductInfoController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/productInfo/GetProductInfo/{productInfoId}")]
        public ProductInfo GetProductInfo(int productInfoId)
        {
            ProductInfoBussiness productInfoBussiness = new ProductInfoBussiness();

            ProductInfo request = productInfoBussiness.ReadProductInfo(productInfoId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/productInfo/InsertProductInfo")]
        public string InsertProductInfo(ProductInfoSpecific productInfoSpecific)
        {
            ProductInfoBussiness productInfoBussiness = new ProductInfoBussiness();

            bool introduced_well = productInfoBussiness.InsertProductInfo(productInfoSpecific);

            if (introduced_well == true)
            {
                return "ProductInfo introduced satisfactorily.";
            }
            else
            {
                return "Error !!! ProductInfo could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/productInfo/UpdateProductInfo")]
        public string UpdateProductInfo(ProductInfoSpecific update)
        {
            ProductInfoBussiness productInfoBussiness = new ProductInfoBussiness();

            bool updated_well = productInfoBussiness.UpdateProductInfo(update);

            if (updated_well == true)
            {
                return "ProductInfo updated satisfactorily.";
            }
            else
            {
                return "Error !!! ProductInfo could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/productInfo/DeleteProductInfo/{productInfoId}")]
        public string DeleteProductInfo(int productInfoId)
        {
            ProductInfoBussiness productInfoBussiness = new ProductInfoBussiness();

            bool deleted_well = productInfoBussiness.DeleteProductInfo(productInfoId);

            if (deleted_well == true)
            {
                return "ProductInfo deleted satisfactorily.";
            }
            else
            {
                return "Error !!! ProductInfo could not be deleted.";
            }

        }
    }
}
