using Sale_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Interfaces
{
    public interface ISaleRepository
    {
        bool Insert(Sale add);

        Sale Read(int EmployeeId);

        bool Update(Sale original, Sale upda);

        bool Delete(Sale del);
    }
}
