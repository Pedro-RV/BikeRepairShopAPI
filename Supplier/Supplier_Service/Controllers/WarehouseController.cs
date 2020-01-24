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
    public class WarehouseController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/warehouse/WarehousesBiggerThanAnExtensionList/{extension}")]
        public List<Warehouse> WarehousesBiggerThanAnExtensionList(int extension)
        {
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            List<Warehouse> request = warehouseBussiness.WarehousesBiggerThanAnExtensionList(extension);

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/warehouse/GetWarehouse/{warehouseId}")]
        public Warehouse GetWarehouse(int warehouseId)
        {
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            Warehouse request = warehouseBussiness.ReadWarehouse(warehouseId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/warehouse/InsertWarehouse")]
        public string InsertWarehouse(WarehouseSpecific warehouseSpecific)
        {
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            bool introduced_well = warehouseBussiness.InsertWarehouse(warehouseSpecific);

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
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            bool updated_well = warehouseBussiness.UpdateWarehouse(update);

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
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            bool deleted_well = warehouseBussiness.DeleteWarehouse(warehouseId);

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
