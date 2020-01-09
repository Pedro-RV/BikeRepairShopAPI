﻿using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface IProductStateBussiness
    {
        bool InsertProductState(string ProductStateDescription);

        ProductState ReadProductState(int ProductId);

        bool UpdateProductState(int ProductStateId, string ProductStateDescription);

        bool DeleteProductState(int ProductStateId);
    }
}
