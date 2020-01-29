using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Bussiness.Interfaces
{
    public interface IBillBussiness
    {
        bool InsertBill(BillSpecific billSpecific);

        Bill ReadBill(int BillId);

        bool UpdateBill(BillSpecific update);

        bool DeleteBill(int BillId);
    }
}
