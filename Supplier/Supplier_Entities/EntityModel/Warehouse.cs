using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplier_Entities.EntityModel
{
    [Table("Warehouse")]
    public class Warehouse
    {
        public Warehouse()
        {

        }

        public Warehouse(string WarehouseAddress, int Extension, WarehouseAdmin WarehouseAdmin)
        {
            this.WarehouseAddress = WarehouseAddress;
            this.Extension = Extension;
            this.WarehouseAdmin = WarehouseAdmin;

            if(WarehouseAdmin != null)
            {
                this.WarehouseAdminId = WarehouseAdmin.WarehouseAdminId;
            }
            else
            {
                this.WarehouseAdminId = 0;
            }

        }

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }

        public int WarehouseAdminId { get; set; }

        [MaxLength(100)]
        public string WarehouseAddress { get; set; }

        public int Extension { get; set; }

        #endregion

        #region Foreing keys

        public WarehouseAdmin WarehouseAdmin { get; set; }

        #endregion
    }
}
