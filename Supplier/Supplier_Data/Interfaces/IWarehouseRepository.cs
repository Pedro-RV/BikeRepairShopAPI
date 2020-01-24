using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface IWarehouseRepository
    {
        List<Warehouse> WarehousesBiggerThanAnExtensionList(int extension);

        bool Insert(Warehouse add);

        Warehouse Read(int WarehouseId);

        bool Update(Warehouse update);

        bool Delete(Warehouse del);

    }
}
