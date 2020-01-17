using Supplier_Bussiness;
using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Supplier_Service.Controllers
{
    public class WarehouseAdminController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/warehouseAdmin/GetWarehouseAdmin/{warehouseAdminId}")]
        public WarehouseAdmin GetWarehouseAdmin(int warehouseAdminId)
        {
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();

            WarehouseAdmin request = warehouseAdminBussiness.ReadWarehouseAdmin(warehouseAdminId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/warehouseAdmin/InsertWarehouseAdmin")]
        public string InsertWarehouseAdmin(WarehouseAdmin warehouseAdminAdd)
        {
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();
            EmployeeBussiness employeeBussiness = new EmployeeBussiness();

            Employee attach = employeeBussiness.ReadEmployee(warehouseAdminAdd.EmployeeId);

            warehouseAdminAdd.Employee = attach;

            bool introduced_well = warehouseAdminBussiness.InsertWarehouseAdmin(warehouseAdminAdd);

            if (introduced_well == true)
            {
                return "WarehouseAdmin introduced satisfactorily.";
            }
            else
            {
                return "Error !!! WarehouseAdmin could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/warehouseAdmin/UpdateWarehouseAdmin")]
        public string UpdateWarehouseAdmin(WarehouseAdmin update)
        {
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();

            bool updated_well = warehouseAdminBussiness.UpdateWarehouseAdmin(update);

            if (updated_well == true)
            {
                return "WarehouseAdmin updated satisfactorily.";
            }
            else
            {
                return "Error !!! WarehouseAdmin could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/warehouseAdmin/DeleteWarehouseAdmin/{warehouseAdminId}")]
        public string DeleteWarehouseAdmin(int warehouseAdminId)
        {
            WarehouseAdminBussiness warehouseAdminBussiness = new WarehouseAdminBussiness();

            bool deleted_well = warehouseAdminBussiness.DeleteWarehouseAdmin(warehouseAdminId);

            if (deleted_well == true)
            {
                return "WarehouseAdmin deleted satisfactorily.";
            }
            else
            {
                return "Error !!! WarehouseAdmin could not be deleted.";
            }

        }
    }
}
