using Sale_Bussiness;
using Sale_Bussiness.Interfaces;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sale_Service.Controllers
{
    public class TransportCompanyController : ApiController
    {
        private ITransportCompanyBussiness transportCompanyBussiness;

        public TransportCompanyController(ITransportCompanyBussiness transportCompanyBussiness)
        {
            this.transportCompanyBussiness = transportCompanyBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/transportCompany/GetTransportCompany/{transportCompanyId}")]
        public TransportCompany GetTransportCompany(int transportCompanyId)
        {
            TransportCompany request = this.transportCompanyBussiness.ReadTransportCompany(transportCompanyId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/transportCompany/InsertTransportCompany")]
        public string InsertTransportCompany(TransportCompanySpecific transportCompanySpecific)
        {
            bool introduced_well = this.transportCompanyBussiness.InsertTransportCompany(transportCompanySpecific);

            if (introduced_well == true)
            {
                return "TransportCompany introduced satisfactorily.";
            }
            else
            {
                return "Error !!! TransportCompany could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/transportCompany/UpdateTransportCompany")]
        public string UpdateTransportCompany(TransportCompanySpecific update)
        {
            bool updated_well = this.transportCompanyBussiness.UpdateTransportCompany(update);

            if (updated_well == true)
            {
                return "TransportCompany updated satisfactorily.";
            }
            else
            {
                return "Error !!! TransportCompany could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/transportCompany/DeleteTransportCompany/{transportCompanyId}")]
        public string DeleteTransportCompany(int transportCompanyId)
        {
            bool deleted_well = this.transportCompanyBussiness.DeleteTransportCompany(transportCompanyId);

            if (deleted_well == true)
            {
                return "TransportCompany deleted satisfactorily.";
            }
            else
            {
                return "Error !!! TransportCompany could not be deleted.";
            }

        }
    }
}
