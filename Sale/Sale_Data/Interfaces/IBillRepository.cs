using Sale_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Interfaces
{
    public interface IBillRepository
    {
        bool Insert(Bill add);

        Bill Read(int BillId);

        bool Update(Bill update);

        bool Delete(Bill del);
    }
}
