using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface ISupplyCompanyBussiness
    {
        bool InsertSupplyCompany(SupplyCompanySpecific supplyCompanySpecific);

        SupplyCompany ReadSupplyCompany(int SupplyCompanyId);

        bool UpdateSupplyCompany(SupplyCompanySpecific update);

        bool DeleteSupplyCompany(int SupplyCompanyId);
    }
}
