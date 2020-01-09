using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface IPurchaseRepository
    {
        List<Purchase> PurchasesBiggerThanAPrizeList(double prize);

        bool Insert(Purchase add);

        Purchase Read(int PurchaseId);

        bool Update(Purchase update);

        bool Delete(Purchase del);

    }
}
