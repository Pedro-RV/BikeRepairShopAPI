using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface IProductTypeRepository
    {
        bool Insert(ProductType add);

        ProductType Read(int ProductTypeId);

        bool Update(ProductType update);

        bool Delete(ProductType del);
    }
}
