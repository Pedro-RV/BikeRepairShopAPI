using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface ISupplyCompanyRepository
    {
        bool Insert(SupplyCompany add);

        SupplyCompany Read(int SupplyCompanyId);

        bool Update(SupplyCompany update);

        bool Delete(SupplyCompany del);

    }
}
