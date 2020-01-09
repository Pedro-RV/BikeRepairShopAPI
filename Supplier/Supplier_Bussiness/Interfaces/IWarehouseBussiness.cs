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

        bool InsertWarehouse(string WarehouseAddress, int Extension, int WarehouseAdminId);

        bool InsertWarehouseAndAdmin(string WarehouseAddress, int Extension, DateTime StartDate, int EmployeeId);

        Warehouse ReadWarehouse(int WarehouseId);

        bool UpdateWarehouse(int WarehouseId, string WarehouseAddress, int Extension, int WarehouseAdminId);

        bool DeleteWarehouse(int WarehouseId);
    }
}
