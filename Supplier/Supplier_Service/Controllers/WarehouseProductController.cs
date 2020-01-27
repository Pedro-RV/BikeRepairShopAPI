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
    public class WarehouseProductController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/WarehouseProduct/GetWarehouseProduct/{WarehouseProductId}")]
        public WarehouseProduct GetWarehouseProduct(int WarehouseProductId)
        {
            WarehouseProductBussiness WarehouseProductBussiness = new WarehouseProductBussiness();

            WarehouseProduct request = WarehouseProductBussiness.ReadWarehouseProduct(WarehouseProductId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/WarehouseProduct/InsertWarehouseProduct")]
        public string InsertWarehouseProduct(WarehouseProductSpecific WarehouseProductSpecific)
        {
            WarehouseProductBussiness WarehouseProductBussiness = new WarehouseProductBussiness();

            bool introduced_well = WarehouseProductBussiness.InsertWarehouseProduct(WarehouseProductSpecific);

            if (introduced_well == true)
            {
                return "WarehouseProduct introduced satisfactorily.";
            }
            else
            {
                return "Error !!! WarehouseProduct could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/WarehouseProduct/UpdateWarehouseProduct")]
        public string UpdateWarehouseProduct(WarehouseProductSpecific update)
        {
            WarehouseProductBussiness WarehouseProductBussiness = new WarehouseProductBussiness();

            bool updated_well = WarehouseProductBussiness.UpdateWarehouseProduct(update);

            if (updated_well == true)
            {
                return "WarehouseProduct updated satisfactorily.";
            }
            else
            {
                return "Error !!! WarehouseProduct could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/WarehouseProduct/DeleteWarehouseProduct/{WarehouseProductId}")]
        public string DeleteWarehouseProduct(int WarehouseProductId)
        {
            WarehouseProductBussiness WarehouseProductBussiness = new WarehouseProductBussiness();

            bool deleted_well = WarehouseProductBussiness.DeleteWarehouseProduct(WarehouseProductId);

            if (deleted_well == true)
            {
                return "WarehouseProduct deleted satisfactorily.";
            }
            else
            {
                return "Error !!! WarehouseProduct could not be deleted.";
            }

        }
    }
}
