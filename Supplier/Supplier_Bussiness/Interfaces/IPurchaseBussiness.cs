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

        bool InsertPurchase(Purchase purchaseAdd);

        bool InsertPurchaseAndProduct(Product productAdd, Purchase purchaseAdd);

        Purchase ReadPurchase(int PurchaseId);

        bool UpdatePurchase(Purchase update);

        bool DeletePurchase(int PurchaseId);

        bool DeletePurchaseAndChangeProduct(int PurchaseId);
    }
}
