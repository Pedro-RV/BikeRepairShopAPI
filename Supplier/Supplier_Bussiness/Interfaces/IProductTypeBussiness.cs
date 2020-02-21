using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IProductTypeBussiness
    {
        bool InsertProductType(ProductTypeSpecific productTypeSpecific);

        ProductType ReadProductType(int ProductTypeId);

        bool UpdateProductType(ProductTypeSpecific update);

        bool DeleteProductType(int ProductTypeId);
    }
}
