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

        bool InsertPurchase(Purchase add);

        bool InsertPurchaseAndProduct(Product add1, Purchase add2);

        Purchase ReadPurchase(int PurchaseId);

        bool UpdatePurchase(Purchase update);

        bool DeletePurchase(int PurchaseId);

        bool DeletePurchaseAndChangeProduct(int PurchaseId);
    }
}
