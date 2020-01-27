using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface IWarehouseProductRepository
    {
        bool Insert(WarehouseProduct add);

        WarehouseProduct Read(int WarehouseProductId);

        bool Update(WarehouseProduct update);

        bool Delete(WarehouseProduct del);
    }
}
