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

        public Warehouse(string WarehouseAddress, int Extension)
        {
            this.WarehouseAddress = WarehouseAddress;
            this.Extension = Extension;
        }

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }

        [MaxLength(100)]
        public string WarehouseAddress { get; set; }

        public int Extension { get; set; }

        #endregion
    }
}
