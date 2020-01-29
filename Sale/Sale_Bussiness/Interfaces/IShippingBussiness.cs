using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Bussiness.Interfaces
{
    public interface IShippingBussiness
    {
        bool InsertShipping(ShippingSpecific shippingSpecific);

        Shipping ReadShipping(int ShippingId);

        bool UpdateShipping(ShippingSpecific update);

        bool DeleteShipping(int ShippingId);
    }
}
