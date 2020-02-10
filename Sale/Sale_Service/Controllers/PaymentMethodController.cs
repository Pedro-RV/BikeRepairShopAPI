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
    public class PaymentMethodController : ApiController
    {
        private IPaymentMethodBussiness paymentMethodBussiness;

        public PaymentMethodController(IPaymentMethodBussiness paymentMethodBussiness)
        {
            this.paymentMethodBussiness = paymentMethodBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/paymentMethod/GetPaymentMethod/{paymentMethodId}")]
        public PaymentMethod GetPaymentMethod(int paymentMethodId)
        {
            PaymentMethod request = this.paymentMethodBussiness.ReadPaymentMethod(paymentMethodId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/paymentMethod/InsertPaymentMethod")]
        public string InsertPaymentMethod(PaymentMethodSpecific paymentMethodSpecific)
        {
            bool introduced_well = this.paymentMethodBussiness.InsertPaymentMethod(paymentMethodSpecific);

            if (introduced_well == true)
            {
                return "PaymentMethod introduced satisfactorily.";
            }
            else
            {
                return "Error !!! PaymentMethod could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/paymentMethod/UpdatePaymentMethod")]
        public string UpdatePaymentMethod(PaymentMethodSpecific update)
        {
            bool updated_well = this.paymentMethodBussiness.UpdatePaymentMethod(update);

            if (updated_well == true)
            {
                return "PaymentMethod updated satisfactorily.";
            }
            else
            {
                return "Error !!! PaymentMethod could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/paymentMethod/DeletePaymentMethod/{paymentMethodId}")]
        public string DeletePaymentMethod(int paymentMethodId)
        {
            bool deleted_well = this.paymentMethodBussiness.DeletePaymentMethod(paymentMethodId);

            if (deleted_well == true)
            {
                return "PaymentMethod deleted satisfactorily.";
            }
            else
            {
                return "Error !!! PaymentMethod could not be deleted.";
            }

        }
    }
}
