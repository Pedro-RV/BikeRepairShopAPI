using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IWarehouseAdminBussiness
    {
        bool InsertWarehouseAdmin(WarehouseAdmin add);

        WarehouseAdmin ReadWarehouseAdmin(int WarehouseAdminId);

        bool UpdateWarehouseAdmin(WarehouseAdmin update);

        bool DeleteWarehouseAdmin(int WarehouseAdminId);
    }
}
