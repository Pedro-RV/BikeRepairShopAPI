using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IWarehouseBussiness
    {
        List<Warehouse> WarehousesBiggerThanAnExtensionList(int extension);

        List<WarehouseData> WarehouseDataList(string warehouseAddress);

        bool InsertWarehouse(Warehouse warehouseAdd);

        bool InsertWarehouseAndAdmin(WarehouseAdmin warehouseAdminAdd, Warehouse warehouseAdd);

        Warehouse ReadWarehouse(int WarehouseId);

        bool UpdateWarehouse(Warehouse update);

        bool DeleteWarehouse(int WarehouseId);
    }
}
