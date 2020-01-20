using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IWarehouseAdminBussiness
    {
        List<WarehouseAdminData> WarehouseAdminDataList();

        bool InsertWarehouseAdmin(WarehouseAdmin warehouseAdminAdd);

        WarehouseAdmin ReadWarehouseAdmin(int WarehouseAdminId);

        bool UpdateWarehouseAdmin(WarehouseAdmin update);

        bool DeleteWarehouseAdmin(int WarehouseAdminId);
    }
}
