using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Supplier_Entities.EntityModel
{
    [DataContract]
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

        [DataMember(Name = "warehouseId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }

        [DataMember(Name = "warehouseAdminId")]
        public int WarehouseAdminId { get; set; }

        [DataMember(Name = "warehouseAddress")]
        [MaxLength(100)]
        public string WarehouseAddress { get; set; }

        [DataMember(Name = "extension")]
        public int Extension { get; set; }

        #endregion

        #region Foreing keys

        [DataMember(Name = "warehouseAdmin")]
        public WarehouseAdmin WarehouseAdmin { get; set; }

        #endregion
    }
}
