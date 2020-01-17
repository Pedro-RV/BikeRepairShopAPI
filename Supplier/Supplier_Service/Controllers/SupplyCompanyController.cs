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
    public class SupplyCompanyController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/supplyCompany/GetSupplyCompany/{supplyCompanyId}")]
        public SupplyCompany GetSupplyCompany(int supplyCompanyId)
        {
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            SupplyCompany request = supplyCompanyBussiness.ReadSupplyCompany(supplyCompanyId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/supplyCompany/InsertSupplyCompany")]
        public string InsertSupplyCompany(SupplyCompany supplyCompanyAdd)
        {
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            bool introduced_well = supplyCompanyBussiness.InsertSupplyCompany(supplyCompanyAdd);

            if (introduced_well == true)
            {
                return "SupplyCompany introduced satisfactorily.";
            }
            else
            {
                return "Error !!! SupplyCompany could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/supplyCompany/UpdateSupplyCompany")]
        public string UpdateSupplyCompany(SupplyCompany update)
        {
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            bool updated_well = supplyCompanyBussiness.UpdateSupplyCompany(update);

            if (updated_well == true)
            {
                return "SupplyCompany updated satisfactorily.";
            }
            else
            {
                return "Error !!! SupplyCompany could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/supplyCompany/DeleteSupplyCompany/{supplyCompanyId}")]
        public string DeleteSupplyCompany(int supplyCompanyId)
        {
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            bool deleted_well = supplyCompanyBussiness.DeleteSupplyCompany(supplyCompanyId);

            if (deleted_well == true)
            {
                return "SupplyCompany deleted satisfactorily.";
            }
            else
            {
                return "Error !!! SupplyCompany could not be deleted.";
            }

        }
    }
}
