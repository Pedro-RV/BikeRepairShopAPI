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
    public class BillController : BaseController
    {
        private IBillBussiness billBussiness;
        private IExceptionController exceptionController;
        private IAuthenticationProvider authenticationProvider;

        public BillController(IBillBussiness billBussiness,
            IExceptionController exceptionController,
            IAuthenticationProvider authenticationProvider)
        {
            this.billBussiness = billBussiness;
            this.exceptionController = exceptionController;
            this.authenticationProvider = authenticationProvider;

        }

        // GET
        [HttpGet]
        [Route("api/bill/GetBill/{billId}")]
        public Bill GetBill(int billId)
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

                Bill result = this.billBussiness.ReadBill(billId);

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
        [Route("api/bill/InsertBill")]
        public string InsertBill(BillSpecific billSpecific)
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

                bool introduced_well = this.billBussiness.InsertBill(billSpecific);

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
        [Route("api/bill/UpdateBill")]
        public string UpdateBill(BillSpecific update)
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

                bool updated_well = this.billBussiness.UpdateBill(update);

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
        [Route("api/bill/DeleteBill/{billId}")]
        public string DeleteBill(int billId)
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

                bool deleted_well = this.billBussiness.DeleteBill(billId);

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
