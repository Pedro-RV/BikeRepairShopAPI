using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Entities.Specific
{
    [DataContract]
    public class ProductSpecific
    {
        public ProductSpecific()
        {

        }

        public ProductSpecific(String ProductDescription, double Prize, int Cuantity, int WarehouseId, int ProductStateId)
        {
            this.ProductDescription = ProductDescription;
            this.Prize = Prize;
            this.Cuantity = Cuantity;
            this.WarehouseId = WarehouseId;
            this.ProductStateId = ProductStateId;

        }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "warehouseId")]
        public int WarehouseId { get; set; }

        [DataMember(Name = "productStateId")]
        public int ProductStateId { get; set; }

        [DataMember(Name = "productDescription")]
        [MaxLength(100)]
        public string ProductDescription { get; set; }

        [DataMember(Name = "prize")]
        public double Prize { get; set; }

        [DataMember(Name = "cuantity")]
        public int Cuantity { get; set; }

    }
}
