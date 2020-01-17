﻿using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface ISupplyCompanyBussiness
    {
        bool InsertSupplyCompany(SupplyCompany supplyCompanyAdd);

        SupplyCompany ReadSupplyCompany(int SupplyCompanyId);

        bool UpdateSupplyCompany(SupplyCompany update);

        bool DeleteSupplyCompany(int SupplyCompanyId);
    }
}
