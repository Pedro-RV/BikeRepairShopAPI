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
    public class ClientController : ApiController
    {
        private IClientBussiness clientBussiness;

        public ClientController(IClientBussiness clientBussiness)
        {
            this.clientBussiness = clientBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/client/GetClient/{clientId}")]
        public Client GetClient(int clientId)
        {
            Client request = this.clientBussiness.ReadClient(clientId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/client/InsertClient")]
        public string InsertClient(ClientSpecific clientSpecific)
        {
            bool introduced_well = this.clientBussiness.InsertClient(clientSpecific);

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
            bool updated_well = this.clientBussiness.UpdateClient(update);

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
            bool deleted_well = this.clientBussiness.DeleteClient(clientId);

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
