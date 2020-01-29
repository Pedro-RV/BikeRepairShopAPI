using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Bussiness.Interfaces
{
    public interface IPaymentMethodBussiness
    {
        bool InsertPaymentMethod(PaymentMethodSpecific paymentMethodSpecific);

        PaymentMethod ReadPaymentMethod(int PaymentMethodId);

        bool UpdatePaymentMethod(PaymentMethodSpecific update);

        bool DeletePaymentMethod(int PaymentMethodId);
    }
}
