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
    public class ClientController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/client/GetClient/{clientId}")]
        public Client GetClient(int clientId)
        {
            ClientBussiness clientBussiness = new ClientBussiness();

            Client request = clientBussiness.ReadClient(clientId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/client/InsertClient")]
        public string InsertClient(ClientSpecific clientSpecific)
        {
            ClientBussiness clientBussiness = new ClientBussiness();

            bool introduced_well = clientBussiness.InsertClient(clientSpecific);

            if (introduced_well == true)
            {
                return "Client introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Client could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/client/UpdateClient")]
        public string UpdateClient(ClientSpecific update)
        {
            ClientBussiness clientBussiness = new ClientBussiness();

            bool updated_well = clientBussiness.UpdateClient(update);

            if (updated_well == true)
            {
                return "Client updated satisfactorily.";
            }
            else
            {
                return "Error !!! Client could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/client/DeleteClient/{clientId}")]
        public string DeleteClient(int clientId)
        {
            ClientBussiness clientBussiness = new ClientBussiness();

            bool deleted_well = clientBussiness.DeleteClient(clientId);

            if (deleted_well == true)
            {
                return "Client deleted satisfactorily.";
            }
            else
            {
                return "Error !!! Client could not be deleted.";
            }

        }
    }
}
