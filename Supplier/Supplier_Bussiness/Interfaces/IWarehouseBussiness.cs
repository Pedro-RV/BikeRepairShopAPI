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

        List<WarehouseData> WarehouseDataList();

        bool InsertWarehouse(Warehouse add);

        bool InsertWarehouseAndAdmin(WarehouseAdmin add1, Warehouse add2);

        Warehouse ReadWarehouse(int WarehouseId);

        bool UpdateWarehouse(Warehouse update);

        bool DeleteWarehouse(int WarehouseId);
    }
}
