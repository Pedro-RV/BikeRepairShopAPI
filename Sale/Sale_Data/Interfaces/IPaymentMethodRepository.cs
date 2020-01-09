using Sale_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Interfaces
{
    public interface IPaymentMethodRepository
    {
        bool Insert(PaymentMethod add);

        PaymentMethod Read(int EmployeeId);

        bool Update(PaymentMethod original, PaymentMethod upda);

        bool Delete(PaymentMethod del);
    }
}
