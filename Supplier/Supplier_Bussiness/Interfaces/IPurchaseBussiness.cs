using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IPurchaseBussiness
    {
        List<Purchase> PurchasesBiggerThanAPrizeList(double prize);

        bool InsertPurchase(DateTime PurchaseDate, int Cuantity, double Prize, int ProductId, int SupplyCompanyId);

        bool InsertPurchaseAndProduct(DateTime PurchaseDate, int PurchaseCuantity, double PurchasePrize, int SupplyCompanyId, String ProductDescription, double ProductPrize, int WarehouseId, int ProductStateId);

        Purchase ReadPurchase(int PurchaseId);

        bool UpdatePurchase(Purchase update);

        bool DeletePurchase(int PurchaseId);

        bool DeletePurchaseAndChangeProduct(int PurchaseId);
    }
}
