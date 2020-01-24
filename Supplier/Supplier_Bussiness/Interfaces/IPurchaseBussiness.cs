using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
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

        List<PurchaseData> PurchaseDataList();

        bool InsertPurchase(PurchaseSpecific purchaseSpecific);

        Purchase ReadPurchase(int PurchaseId);

        bool UpdatePurchase(PurchaseSpecific update);

        bool DeletePurchase(int PurchaseId);

        bool DeletePurchaseAndChangeProduct(int PurchaseId);
    }
}
