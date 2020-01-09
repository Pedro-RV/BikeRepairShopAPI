using Sale_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Interfaces
{
    public interface ITransportCompanyRepository
    {
        bool Insert(TransportCompany add);

        TransportCompany Read(int EmployeeId);

        bool Update(TransportCompany original, TransportCompany upda);

        bool Delete(TransportCompany del);
    }
}
