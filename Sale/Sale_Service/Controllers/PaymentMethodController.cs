using Sale_Bussiness;
using Sale_Bussiness.Interfaces;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using Sale_Helper.Authentication;
using Sale_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Sale_Service.Controllers
{
    public class PaymentMethodController : BaseController
    {
        private IPaymentMethodBussiness paymentMethodBussiness;
        private IExceptionController exceptionController;
        private IAuthenticationProvider authenticationProvider;

        public PaymentMethodController(IPaymentMethodBussiness paymentMethodBussiness,
            IExceptionController exceptionController,
            IAuthenticationProvider authenticationProvider)
        {
            this.paymentMethodBussiness = paymentMethodBussiness;
            this.exceptionController = exceptionController;
            this.authenticationProvider = authenticationProvider;

        }

        // GET
        [HttpGet]
        [Route("api/paymentMethod/GetPaymentMethod/{paymentMethodId}")]
        public PaymentMethod GetPaymentMethod(int paymentMethodId)
        {
            try
            {
                var request = Request;
                HttpRequestHeaders headers = null;

                if (request != null)
                {
                    headers = request.Headers;
                }

                if (!this.authenticationProvider.CheckAuthentication(headers))
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.AuthenticationError);
                }

                PaymentMethod result = this.paymentMethodBussiness.ReadPaymentMethod(paymentMethodId);

                return result;

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }
        }

        // POST
        [HttpPost]
        [Route("api/paymentMethod/InsertPaymentMethod")]
        public string InsertPaymentMethod(PaymentMethodSpecific paymentMethodSpecific)
        {
            try
            {
                var request = Request;
                HttpRequestHeaders headers = null;

                if (request != null)
                {
                    headers = request.Headers;
                }

                if (!this.authenticationProvider.CheckAuthentication(headers))
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.AuthenticationError);
                }

                bool introduced_well = this.paymentMethodBussiness.InsertPaymentMethod(paymentMethodSpecific);

                if (introduced_well == true)
                {
                    return "Action completed satisfactorily.";
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ActionNotCompleted);
                }

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

        }

        // PUT
        [HttpPut]
        [Route("api/paymentMethod/UpdatePaymentMethod")]
        public string UpdatePaymentMethod(PaymentMethodSpecific update)
        {
            try
            {
                var request = Request;
                HttpRequestHeaders headers = null;

                if (request != null)
                {
                    headers = request.Headers;
                }

                if (!this.authenticationProvider.CheckAuthentication(headers))
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.AuthenticationError);
                }

                bool updated_well = this.paymentMethodBussiness.UpdatePaymentMethod(update);

                if (updated_well == true)
                {
                    return "Action completed satisfactorily.";
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ActionNotCompleted);
                }

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/paymentMethod/DeletePaymentMethod/{paymentMethodId}")]
        public string DeletePaymentMethod(int paymentMethodId)
        {
            try
            {
                var request = Request;
                HttpRequestHeaders headers = null;

                if (request != null)
                {
                    headers = request.Headers;
                }

                if (!this.authenticationProvider.CheckAuthentication(headers))
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.AuthenticationError);
                }

                bool deleted_well = this.paymentMethodBussiness.DeletePaymentMethod(paymentMethodId);

                if (deleted_well == true)
                {
                    return "Action completed satisfactorily.";
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ActionNotCompleted);
                }

            }
            catch (SaleException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }

        }
    }
}
