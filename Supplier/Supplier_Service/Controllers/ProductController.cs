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
    public class ProductController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/product/ProductsList")]
        public List<Product> ProductsList()
        {
            ProductBussiness productBussiness = new ProductBussiness();

            List<Product> request = productBussiness.ProductsList();

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/product/ProductDataList")]
        public List<ProductData> ProductDataList()
        {
            ProductBussiness productBussiness = new ProductBussiness();

            List<ProductData> request = productBussiness.ProductDataList();

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/product/GetProduct/{productId}")]
        public Product GetProduct(int productId)
        {
            ProductBussiness productBussiness = new ProductBussiness();

            Product request = productBussiness.ReadProduct(productId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/product/InsertProduct")]
        public string InsertProduct(ProductSpecific productSpecific)
        {
            ProductBussiness productBussiness = new ProductBussiness();

            bool introduced_well = productBussiness.InsertProduct(productSpecific);

            if (introduced_well == true)
            {
                return "Product introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Product could not be introduced.";
            }

        }      

        // PUT
        [HttpPut]
        [Route("api/product/UpdateProduct")]
        public string UpdateProduct(ProductSpecific update)
        {
            ProductBussiness productBussiness = new ProductBussiness();

            bool updated_well = productBussiness.UpdateProduct(update);

            if (updated_well == true)
            {
                return "Product updated satisfactorily.";
            }
            else
            {
                return "Error !!! Product could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/product/DeleteProduct/{productId}")]
        public string DeleteProduct(int productId)
        {
            ProductBussiness productBussiness = new ProductBussiness();

            bool deleted_well = productBussiness.DeleteProduct(productId);

            if (deleted_well == true)
            {
                return "Product deleted satisfactorily.";
            }
            else
            {
                return "Error !!! Product could not be deleted.";
            }

        }
    }
}
