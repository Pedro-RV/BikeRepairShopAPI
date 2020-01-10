﻿using Sale_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Interfaces
{
    public interface IShippingRepository
    {
        bool Insert(Shipping add);

        Shipping Read(int EmployeeId);

        bool Update(Shipping original, Shipping upda);

        bool Delete(Shipping del);
    }
}