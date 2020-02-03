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
    public class WarehouseProductController : ApiController
    {
        private IWarehouseProductBussiness warehouseProductBussiness;

        public WarehouseProductController(IWarehouseProductBussiness warehouseProductBussiness)
        {
            this.warehouseProductBussiness = warehouseProductBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/WarehouseProduct/GetWarehouseProduct/{WarehouseProductId}")]
        public WarehouseProduct GetWarehouseProduct(int WarehouseProductId)
        {
            WarehouseProduct request = this.warehouseProductBussiness.ReadWarehouseProduct(WarehouseProductId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/WarehouseProduct/InsertWarehouseProduct")]
        public string InsertWarehouseProduct(WarehouseProductSpecific WarehouseProductSpecific)
        {
            bool introduced_well = this.warehouseProductBussiness.InsertWarehouseProduct(WarehouseProductSpecific);

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
            bool updated_well = this.warehouseProductBussiness.UpdateWarehouseProduct(update);

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
            bool deleted_well = this.warehouseProductBussiness.DeleteWarehouseProduct(WarehouseProductId);

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
