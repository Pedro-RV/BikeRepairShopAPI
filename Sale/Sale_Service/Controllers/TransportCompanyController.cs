using Sale_Bussiness;
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
        // GET
        [HttpGet]
        [Route("api/transportCompany/GetTransportCompany/{transportCompanyId}")]
        public TransportCompany GetTransportCompany(int transportCompanyId)
        {
            TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();

            TransportCompany request = transportCompanyBussiness.ReadTransportCompany(transportCompanyId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/transportCompany/InsertTransportCompany")]
        public string InsertTransportCompany(TransportCompanySpecific transportCompanySpecific)
        {
            TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();

            bool introduced_well = transportCompanyBussiness.InsertTransportCompany(transportCompanySpecific);

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
            TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();

            bool updated_well = transportCompanyBussiness.UpdateTransportCompany(update);

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
            TransportCompanyBussiness transportCompanyBussiness = new TransportCompanyBussiness();

            bool deleted_well = transportCompanyBussiness.DeleteTransportCompany(transportCompanyId);

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
