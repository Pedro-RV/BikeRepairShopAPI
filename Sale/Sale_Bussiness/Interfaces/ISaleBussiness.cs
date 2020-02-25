using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using Sale_Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Bussiness.Interfaces
{
    public interface ISaleBussiness
    {
        bool InsertSale(SaleSpecific saleSpecific, PaymentMethodEnum paymentMethodEnum);

        Sale ReadSale(int SaleId);

        bool UpdateSale(SaleSpecific update);

        bool DeleteSale(int SaleId);
    }
}
