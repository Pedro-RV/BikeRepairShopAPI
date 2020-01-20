using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface IWarehouseAdminRepository
    {
        List<WarehouseAdminData> WarehouseAdminDataList();

        bool Insert(WarehouseAdmin add);

        WarehouseAdmin Read(int WarehouseAdminId);

        bool Update(WarehouseAdmin update);

        bool Delete(WarehouseAdmin del);

    }
}
