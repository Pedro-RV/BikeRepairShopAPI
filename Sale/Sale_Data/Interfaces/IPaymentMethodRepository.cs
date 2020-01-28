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

        PaymentMethod Read(int PaymentMethodId);

        bool Update(PaymentMethod update);

        bool Delete(PaymentMethod del);
    }
}
