using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using Supplier_Helper.Authentication;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Supplier_Service.Controllers
{
    public class PurchaseController : BaseController
    {
        private IPurchaseBussiness purchaseBussiness;
        private IExceptionController exceptionController;
        private IAuthenticationProvider authenticationProvider;

        public PurchaseController(IPurchaseBussiness purchaseBussiness,
            IExceptionController exceptionController,
            IAuthenticationProvider authenticationProvider)
        {
            this.purchaseBussiness = purchaseBussiness;
            this.exceptionController = exceptionController;
            this.authenticationProvider = authenticationProvider;

        }

        // GET
        [HttpGet]
        [Route("api/purchase/PurchasesBiggerThanAPrizeList/{prize}")]
        public List<Purchase> PurchasesBiggerThanAPrizeList(double prize)
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

                List<Purchase> result = this.purchaseBussiness.PurchasesBiggerThanAPrizeList(prize);

                return result;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }
        }

        // GET
        [HttpGet]
        [Route("api/purchase/PurchaseDataList")]
        public List<PurchaseData> PurchaseDataList()
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

                List<PurchaseData> result = this.purchaseBussiness.PurchaseDataList();

                return result;

            }
            catch (SupplierException)
            {
                throw;
            }
            catch (Exception)
            {
                throw this.exceptionController.CreateMyException(ExceptionEnum.InvalidRequest);
            }
        }

        // GET
        [HttpGet]
        [Route("api/purchase/GetPurchase/{purchaseId}")]
        public Purchase GetPurchase(int purchaseId)
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

                Purchase result = this.purchaseBussiness.ReadPurchase(purchaseId);

                return result;

            }
            catch (SupplierException)
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
        [Route("api/purchase/InsertPurchase")]
        public string InsertPurchase(PurchaseSpecific purchaseSpecific)
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

                bool introduced_well = this.purchaseBussiness.InsertPurchase(purchaseSpecific);

                if (introduced_well == true)
                {
                    return "Action completed satisfactorily.";
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ActionNotCompleted);
                }

            }
            catch (SupplierException)
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
        [Route("api/purchase/UpdatePurchase")]
        public string UpdatePurchase(PurchaseSpecific purchaseSpecific)
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

                bool updated_well = this.purchaseBussiness.UpdatePurchase(purchaseSpecific);

                if (updated_well == true)
                {
                    return "Action completed satisfactorily.";
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ActionNotCompleted);
                }

            }
            catch (SupplierException)
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
        [Route("api/purchase/DeletePurchase/{purchaseId}")]
        public string DeletePurchase(int purchaseId)
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

                bool deleted_well = this.purchaseBussiness.DeletePurchase(purchaseId);

                if (deleted_well == true)
                {
                    return "Action completed satisfactorily.";
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ActionNotCompleted);
                }

            }
            catch (SupplierException)
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
        [Route("api/purchase/DeletePurchaseAndChangeProduct/{purchaseId}")]
        public string DeletePurchaseAndChangeProduct(int purchaseId)
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

                bool deleted_well = this.purchaseBussiness.DeletePurchaseAndChangeProduct(purchaseId);

                if (deleted_well == true)
                {
                    return "Action completed satisfactorily.";
                }
                else
                {
                    throw this.exceptionController.CreateMyException(ExceptionEnum.ActionNotCompleted);
                }

            }
            catch (SupplierException)
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
