using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Bussiness.Interfaces
{
    public interface IProductBussiness
    {
        bool InsertProduct(ProductSpecific productSpecific);

        Product ReadProduct(int ProductId);

        bool UpdateProduct(ProductSpecific update);

        bool DeleteProduct(int ProductId);
    }
}
