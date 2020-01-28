using Sale_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Interfaces
{
    public interface IProductRepository
    {
        bool Insert(Product add);

        Product Read(int ProductId);

        bool Update(Product update);

        bool Delete(Product del);
    }
}
