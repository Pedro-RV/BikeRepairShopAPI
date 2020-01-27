using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface IProductInfoRepository
    {
        bool Insert(ProductInfo add);

        ProductInfo Read(int ProductInfoId);

        bool Update(ProductInfo update);

        bool Delete(ProductInfo del);
    }
}
