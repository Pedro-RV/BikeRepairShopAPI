using Sale_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Interfaces
{
    public interface IClientRepository
    {
        bool Insert(Client add);

        Client Read(int EmployeeId);

        bool Update(Client original, Client upda);

        bool Delete(Client del);
    }
}
