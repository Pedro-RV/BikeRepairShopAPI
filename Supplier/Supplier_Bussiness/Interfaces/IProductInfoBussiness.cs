using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IProductInfoBussiness
    {
        bool InsertProductInfo(ProductInfoSpecific productInfoSpecific);

        ProductInfo ReadProductInfo(int ProductInfoId);

        bool UpdateProductInfo(ProductInfoSpecific update);

        bool DeleteProductInfo(int ProductInfoId);
    }
}
