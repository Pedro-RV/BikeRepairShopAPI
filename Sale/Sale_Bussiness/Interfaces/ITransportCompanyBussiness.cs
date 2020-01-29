using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Bussiness.Interfaces
{
    public interface ITransportCompanyBussiness
    {
        bool InsertTransportCompany(TransportCompanySpecific transportCompanySpecific);

        TransportCompany ReadTransportCompany(int TransportCompanyId);

        bool UpdateTransportCompany(TransportCompanySpecific update);

        bool DeleteTransportCompany(int TransportCompanyId);
    }
}
