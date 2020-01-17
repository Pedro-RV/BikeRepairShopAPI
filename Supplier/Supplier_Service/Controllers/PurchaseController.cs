using Supplier_Bussiness;
using Supplier_Entities.EntityModel;
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
        // GET
        [HttpGet]
        [Route("api/purchase/PurchasesBiggerThanAPrizeList/{prize}")]
        public List<Purchase> PurchasesBiggerThanAPrizeList(double prize)
        {
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            List<Purchase> request = purchaseBussiness.PurchasesBiggerThanAPrizeList(prize);

            return request;
        }      

        // GET
        [HttpGet]
        [Route("api/purchase/GetPurchase/{purchaseId}")]
        public Purchase GetPurchase(int purchaseId)
        {
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            Purchase request = purchaseBussiness.ReadPurchase(purchaseId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/purchase/InsertPurchase")]
        public string InsertPurchase(Purchase purchaseAdd)
        {
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();
            ProductBussiness productBussiness = new ProductBussiness();
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();

            Product attachProduct = productBussiness.ReadProduct(purchaseAdd.ProductId);

            purchaseAdd.Product = attachProduct;

            SupplyCompany attachSupplyCompany = supplyCompanyBussiness.ReadSupplyCompany(purchaseAdd.SupplyCompanyId);

            purchaseAdd.SupplyCompany = attachSupplyCompany;

            bool introduced_well = purchaseBussiness.InsertPurchase(purchaseAdd);

            if (introduced_well == true)
            {
                return "Purchase introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Purchase could not be introduced.";
            }

        }

        // POST
        [HttpPost]
        [Route("api/purchase/InsertPurchaseAndProduct")]
        public string InsertPurchaseAndProduct(Product productAdd, Purchase purchaseAdd)
        {
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();
            SupplyCompanyBussiness supplyCompanyBussiness = new SupplyCompanyBussiness();
            WarehouseBussiness warehouseBussiness = new WarehouseBussiness();
            ProductStateBussiness productStateBussiness = new ProductStateBussiness();

            Warehouse attachWarehouse = warehouseBussiness.ReadWarehouse(productAdd.WarehouseId);

            productAdd.Warehouse = attachWarehouse;

            ProductState attachProductState = productStateBussiness.ReadProductState(productAdd.ProductStateId);

            productAdd.ProductState = attachProductState;

            SupplyCompany attachSupplyCompany = supplyCompanyBussiness.ReadSupplyCompany(purchaseAdd.SupplyCompanyId);

            purchaseAdd.SupplyCompany = attachSupplyCompany;

            bool introduced_well = purchaseBussiness.InsertPurchaseAndProduct(productAdd, purchaseAdd);

            if (introduced_well == true)
            {
                return "Product and Purchase introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Product and Purchase could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/purchase/UpdatePurchase")]
        public string UpdatePurchase(Purchase update)
        {
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            bool updated_well = purchaseBussiness.UpdatePurchase(update);

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
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            bool deleted_well = purchaseBussiness.DeletePurchase(purchaseId);

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
        [Route("api/purchase/DeletePurchase/{purchaseId}")]
        public string DeletePurchaseAndChangeProduct(int purchaseId)
        {
            PurchaseBussiness purchaseBussiness = new PurchaseBussiness();

            bool deleted_well = purchaseBussiness.DeletePurchaseAndChangeProduct(purchaseId);

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
