﻿using Sale_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Interfaces
{
    public interface IProductTypeRepository
    {
        bool Insert(ProductType add);

        ProductType Read(int EmployeeId);

        bool Update(ProductType original, ProductType upda);

        bool Delete(ProductType del);
    }
}