using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface IProductStateRepository
    {
        bool Insert(ProductState add);

        ProductState Read(int ProductId);

        bool Update(ProductState update);

        bool Delete(ProductState del);

    }
}
