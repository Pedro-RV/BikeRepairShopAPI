using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IWarehouseProductBussiness
    {
        bool InsertWarehouseProduct(WarehouseProductSpecific warehouseProductSpecific);

        WarehouseProduct ReadWarehouseProduct(int WarehouseProductId);

        bool UpdateWarehouseProduct(WarehouseProductSpecific update);

        bool DeleteWarehouseProduct(int WarehouseProductId);
    }
}
