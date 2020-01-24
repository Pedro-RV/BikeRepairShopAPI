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

        bool InsertWarehouse(WarehouseSpecific warehouseSpecific);

        Warehouse ReadWarehouse(int WarehouseId);

        bool UpdateWarehouse(WarehouseSpecific update);

        bool DeleteWarehouse(int WarehouseId);
    }
}
