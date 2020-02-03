using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Supplier_Service.Controllers
{
    public class PurchaseController : ApiController
    {
        private IPurchaseBussiness purchaseBussiness;

        public PurchaseController(IPurchaseBussiness purchaseBussiness)
        {
            this.purchaseBussiness = purchaseBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/purchase/PurchasesBiggerThanAPrizeList/{prize}")]
        public List<Purchase> PurchasesBiggerThanAPrizeList(double prize)
        {
            List<Purchase> request = this.purchaseBussiness.PurchasesBiggerThanAPrizeList(prize);

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/purchase/PurchaseDataList")]
        public List<PurchaseData> PurchaseDataList()
        {
            List<PurchaseData> request = this.purchaseBussiness.PurchaseDataList();

            return request;
        }

        // GET
        [HttpGet]
        [Route("api/purchase/GetPurchase/{purchaseId}")]
        public Purchase GetPurchase(int purchaseId)
        {
            Purchase request = this.purchaseBussiness.ReadPurchase(purchaseId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/purchase/InsertPurchase")]
        public string InsertPurchase(PurchaseSpecific purchaseSpecific)
        {
            bool introduced_well = this.purchaseBussiness.InsertPurchase(purchaseSpecific);

            if (introduced_well == true)
            {
                return "Purchase introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Purchase could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/purchase/UpdatePurchase")]
        public string UpdatePurchase(PurchaseSpecific purchaseSpecific)
        {
            bool updated_well = this.purchaseBussiness.UpdatePurchase(purchaseSpecific);

            if (updated_well == true)
            {
                return "Purchase updated satisfactorily.";
            }
            else
            {
                return "Error !!! Purchase could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/purchase/DeletePurchase/{purchaseId}")]
        public string DeletePurchase(int purchaseId)
        {
            bool deleted_well = this.purchaseBussiness.DeletePurchase(purchaseId);

            if (deleted_well == true)
            {
                return "Purchase deleted satisfactorily.";
            }
            else
            {
                return "Error !!! Purchase could not be deleted.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/purchase/DeletePurchaseAndChangeProduct/{purchaseId}")]
        public string DeletePurchaseAndChangeProduct(int purchaseId)
        {
            bool deleted_well = this.purchaseBussiness.DeletePurchaseAndChangeProduct(purchaseId);

            if (deleted_well == true)
            {
                return "Purchase deleted and Product changed satisfactorily.";
            }
            else
            {
                return "Error !!! Purchase could not be deleted and Product could not be changed.";
            }

        }
    }
}
