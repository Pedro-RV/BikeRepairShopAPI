﻿using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
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

        List<WarehouseAdminData> WarehouseAdminDataListWithDapper(string warehouseAddress);

        bool Insert(WarehouseAdmin add);

        WarehouseAdmin Read(int WarehouseAdminId);

        bool Update(WarehouseAdmin update);

        bool Delete(WarehouseAdmin del);

    }
}
