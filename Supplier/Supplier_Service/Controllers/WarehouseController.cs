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
    public class WarehouseController : ApiController
    {
        private IWarehouseBussiness warehouseBussiness;

        public WarehouseController(IWarehouseBussiness warehouseBussiness)
        {
            this.warehouseBussiness = warehouseBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/warehouse/WarehousesBiggerThanAnExtensionList/{extension}")]
        public List<Warehouse> WarehousesBiggerThanAnExtensionList(int extension)
        {
            List<Warehouse> request = this.warehouseBussiness.WarehousesBiggerThanAnExtensionList(extension);

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/warehouse/GetWarehouse/{warehouseId}")]
        public Warehouse GetWarehouse(int warehouseId)
        {
            Warehouse request = this.warehouseBussiness.ReadWarehouse(warehouseId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/warehouse/InsertWarehouse")]
        public string InsertWarehouse(WarehouseSpecific warehouseSpecific)
        {
            bool introduced_well = this.warehouseBussiness.InsertWarehouse(warehouseSpecific);

            if (introduced_well == true)
            {
                return "Warehouse introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Warehouse could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/warehouse/UpdateWarehouse")]
        public string UpdateWarehouse(WarehouseSpecific update)
        {
            bool updated_well = this.warehouseBussiness.UpdateWarehouse(update);

            if (updated_well == true)
            {
                return "Warehouse updated satisfactorily.";
            }
            else
            {
                return "Error !!! Warehouse could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/warehouse/DeleteWarehouse/{warehouseId}")]
        public string DeleteWarehouse(int warehouseId)
        {
            bool deleted_well = this.warehouseBussiness.DeleteWarehouse(warehouseId);

            if (deleted_well == true)
            {
                return "Warehouse deleted satisfactorily.";
            }
            else
            {
                return "Error !!! Warehouse could not be deleted.";
            }

        }
    }
}
