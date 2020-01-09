using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Entities.Specific
{
    public partial class WarehouseData
    {
        public WarehouseData()
        {

        }

        public WarehouseData(int WarehouseId, string Address, string DNI, string Email)
        {
            this.WarehouseId = WarehouseId;
            this.Address = Address;
            this.DNI = DNI;
            this.Email = Email;
        }

        public int WarehouseId { get; set; }

        public string Address { get; set; }

        public string DNI { get; set; }

        public string Email { get; set; }

    }
}
