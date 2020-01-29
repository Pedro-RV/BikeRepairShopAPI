using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Bussiness.Interfaces
{
    public interface IClientBussiness
    {
        bool InsertClient(ClientSpecific clientSpecific);

        Client ReadClient(int ClientId);

        bool UpdateClient(ClientSpecific update);

        bool DeleteClient(int ClientId);
    }
}
