using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IProductStateBussiness
    {
        bool InsertProductState(ProductState productStateAdd);

        ProductState ReadProductState(int ProductId);

        bool UpdateProductState(ProductState update);

        bool DeleteProductState(int ProductStateId);
    }
}
