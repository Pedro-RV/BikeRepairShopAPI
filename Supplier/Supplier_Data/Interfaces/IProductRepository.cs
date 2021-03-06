﻿using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface IProductRepository
    {
        List<Product> ProductsList();

        bool Insert(Product add);

        Product Read(int ProductId);

        bool Update(Product update);

        bool Delete(Product del);

    }
}
