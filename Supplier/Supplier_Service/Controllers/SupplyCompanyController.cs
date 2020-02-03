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
    public class SupplyCompanyController : ApiController
    {
        private ISupplyCompanyBussiness supplyCompanyBussiness;

        public SupplyCompanyController(ISupplyCompanyBussiness supplyCompanyBussiness)
        {
            this.supplyCompanyBussiness = supplyCompanyBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/supplyCompany/GetSupplyCompany/{supplyCompanyId}")]
        public SupplyCompany GetSupplyCompany(int supplyCompanyId)
        {
            SupplyCompany request = this.supplyCompanyBussiness.ReadSupplyCompany(supplyCompanyId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/supplyCompany/InsertSupplyCompany")]
        public string InsertSupplyCompany(SupplyCompanySpecific supplyCompanySpecific)
        {
            bool introduced_well = this.supplyCompanyBussiness.InsertSupplyCompany(supplyCompanySpecific);

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
        public string UpdateSupplyCompany(SupplyCompanySpecific update)
        {
            bool updated_well = this.supplyCompanyBussiness.UpdateSupplyCompany(update);

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
            bool deleted_well = this.supplyCompanyBussiness.DeleteSupplyCompany(supplyCompanyId);

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
