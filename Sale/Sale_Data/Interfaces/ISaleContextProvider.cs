using Sale_Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Interfaces
{
    public interface ISaleContextProvider
    {
        void InitializeSaleContext();

        SaleContext GetSaleContext();
    }
}
