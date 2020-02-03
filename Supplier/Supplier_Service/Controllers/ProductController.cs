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
    public class ProductController : ApiController
    {
        private IProductBussiness productBussiness;

        public ProductController(IProductBussiness productBussiness)
        {
            this.productBussiness = productBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/product/ProductsList")]
        public List<Product> ProductsList()
        {
            List<Product> request = this.productBussiness.ProductsList();

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/product/GetProduct/{productId}")]
        public Product GetProduct(int productId)
        {
            Product request = this.productBussiness.ReadProduct(productId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/product/InsertProduct")]
        public string InsertProduct(ProductSpecific productSpecific)
        {
            bool introduced_well = this.productBussiness.InsertProduct(productSpecific);

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
            bool updated_well = this.productBussiness.UpdateProduct(update);

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
            bool deleted_well = this.productBussiness.DeleteProduct(productId);

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
