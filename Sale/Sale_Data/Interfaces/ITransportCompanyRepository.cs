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

        TransportCompany Read(int TransportCompanyId);

        bool Update(TransportCompany update);

        bool Delete(TransportCompany del);
    }
}
