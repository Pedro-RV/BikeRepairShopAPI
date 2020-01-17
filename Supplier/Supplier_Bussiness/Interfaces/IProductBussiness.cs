using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IProductBussiness
    {
        List<Product> ProductsList();

        List<ProductData> ProductDataList();

        bool InsertProduct(Product productAdd);

        Product ReadProduct(int ProductId);

        bool UpdateProduct(Product update);

        bool DeleteProduct(int ProductId);
    }
}
