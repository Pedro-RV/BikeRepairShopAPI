using Sale_Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Context
{
    public class SaleContextProvider : ISaleContextProvider
    {
        private static SaleContext _instance;

        public SaleContextProvider()
        {
        }

        public void InitializeSaleContext()
        {
            if (_instance == null)
            {
                _instance = new SaleContext();
            }
        }

        public SaleContext GetSaleContext()
        {
            return _instance;
        }
    }
}
