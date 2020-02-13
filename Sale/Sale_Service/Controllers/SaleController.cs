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
    public class SaleController : BaseController
    {
        private ISaleBussiness saleBussiness;
        private IExceptionController exceptionController;
        private IAuthenticationProvider authenticationProvider;

        public SaleController(ISaleBussiness saleBussiness,
            IExceptionController exceptionController,
            IAuthenticationProvider authenticationProvider)
        {
            this.saleBussiness = saleBussiness;
            this.exceptionController = exceptionController;
            this.authenticationProvider = authenticationProvider;

        }

        // GET
        [HttpGet]
        [Route("api/sale/GetSale/{saleId}")]
        public Sale GetSale(int saleId)
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

                Sale result = this.saleBussiness.ReadSale(saleId);

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
        [Route("api/sale/InsertSale")]
        public string InsertSale(SaleSpecific saleSpecific)
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

                bool introduced_well = this.saleBussiness.InsertSale(saleSpecific);

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
        [Route("api/sale/UpdateSale")]
        public string UpdateSale(SaleSpecific update)
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

                bool updated_well = this.saleBussiness.UpdateSale(update);

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
        [Route("api/sale/DeleteSale/{saleId}")]
        public string DeleteSale(int saleId)
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

                bool deleted_well = this.saleBussiness.DeleteSale(saleId);

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
