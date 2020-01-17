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
        [Route("api/warehouse/WarehouseDataList")]
        public List<WarehouseData> WarehouseDataList()
        {
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();

            List<WarehouseData> request = warehouseBussiness.WarehouseDataList();

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
        public string InsertWarehouse(Warehouse warehouseAdd)
        {
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();

            WarehouseAdmin attachWarehouseAdmin = warehouseAdminBussiness.ReadWarehouseAdmin(warehouseAdd.WarehouseAdminId);

            warehouseAdd.WarehouseAdmin = attachWarehouseAdmin;

            bool introduced_well = warehouseBussiness.InsertWarehouse(warehouseAdd);

            if (introduced_well == true)
            {
                return "Warehouse introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Warehouse could not be introduced.";
            }

        }

        // POST
        [HttpPost]
        [Route("api/warehouse/InsertWarehouseAndAdmin")]
        public string InsertWarehouseAndAdmin(WarehouseAdmin warehouseAdminAdd, Warehouse warehouseAdd)
        {
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();

            Employee attachEmployee = employeeBussiness.ReadEmployee(warehouseAdminAdd.EmployeeId);

            warehouseAdminAdd.Employee = attachEmployee;

            bool introduced_well = warehouseBussiness.InsertWarehouseAndAdmin(warehouseAdminAdd, warehouseAdd);

            if (introduced_well == true)
            {
                return "WarehouseAdmin and Warehouse introduced satisfactorily.";
            }
            else
            {
                return "Error !!! WarehouseAdmin and Warehouse could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/warehouse/UpdateWarehouse")]
        public string UpdateWarehouse(Warehouse update)
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
