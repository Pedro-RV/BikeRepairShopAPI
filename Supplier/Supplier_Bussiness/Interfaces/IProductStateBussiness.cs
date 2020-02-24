using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IProductStateBussiness
    {
        bool InsertProductState(ProductStateSpecific productStateSpecific);

        ProductState ReadProductState(int ProductId);

        bool UpdateProductState(ProductStateSpecific update);

        bool DeleteProductState(int ProductStateId);
    }
}
