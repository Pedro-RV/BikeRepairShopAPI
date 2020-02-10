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
    public class ShippingController : ApiController
    {
        private IShippingBussiness shippingBussiness;

        public ShippingController(IShippingBussiness shippingBussiness)
        {
            this.shippingBussiness = shippingBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/shipping/GetShipping/{shippingId}")]
        public Shipping GetShipping(int shippingId)
        {
            Shipping request = this.shippingBussiness.ReadShipping(shippingId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/shipping/InsertShipping")]
        public string InsertShipping(ShippingSpecific shippingSpecific)
        {
            bool introduced_well = this.shippingBussiness.InsertShipping(shippingSpecific);

            if (introduced_well == true)
            {
                return "Shipping introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Shipping could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/shipping/UpdateShipping")]
        public string UpdateShipping(ShippingSpecific update)
        {
            bool updated_well = this.shippingBussiness.UpdateShipping(update);

            if (updated_well == true)
            {
                return "Shipping updated satisfactorily.";
            }
            else
            {
                return "Error !!! Shipping could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/shipping/DeleteShipping/{shippingId}")]
        public string DeleteShipping(int shippingId)
        {
            bool deleted_well = this.shippingBussiness.DeleteShipping(shippingId);

            if (deleted_well == true)
            {
                return "Shipping deleted satisfactorily.";
            }
            else
            {
                return "Error !!! Shipping could not be deleted.";
            }

        }
    }
}
