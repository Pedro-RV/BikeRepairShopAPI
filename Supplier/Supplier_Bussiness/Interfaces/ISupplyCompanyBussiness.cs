using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Bussiness.Interfaces
{
    public interface ISupplyCompanyBussiness
    {
        bool InsertSupplyCompany(string SupplyCompanyName, string TelephoneNum);

        SupplyCompany ReadSupplyCompany(int SupplyCompanyId);

        bool UpdateSupplyCompany(int SupplyCompanyId, string SupplyCompanyName, string TelephoneNum);

        bool DeleteSupplyCompany(int SupplyCompanyId);
    }
}
