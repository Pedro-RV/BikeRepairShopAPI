using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Context
{
    public class SaleContextProvider
    {
        private static SaleContext _instance;

        public SaleContextProvider()
        {
        }

        public static void InitializeSaleContext()
        {
            if (_instance == null)
            {
                _instance = new SaleContext();
            }
        }

        public static SaleContext GetSaleContext()
        {
            return _instance;
        }
    }
}
