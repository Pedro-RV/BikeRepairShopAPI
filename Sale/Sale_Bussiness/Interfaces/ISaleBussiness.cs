using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Bussiness.Interfaces
{
    public interface ISaleBussiness
    {
        bool InsertSale(SaleSpecific saleSpecific);

        Sale ReadSale(int SaleId);

        bool UpdateSale(SaleSpecific update);

        bool DeleteSale(int SaleId);
    }
}
