using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Supplier_Entities.EntityModel
{
    [DataContract]
    [Table("Product")]
    public class Product
    {
        public Product()
        {

        }

        public Product(String ProductDescription, double Prize, int Cuantity, Warehouse Warehouse, ProductState ProductState)
        {
            this.ProductDescription = ProductDescription;
            this.Prize = Prize;
            this.Cuantity = Cuantity;
            this.Warehouse = Warehouse;

            if(Warehouse != null)
            {
                this.WarehouseId = Warehouse.WarehouseId;
            }
            else
            {
                this.WarehouseId = 0;
            }

            this.ProductState = ProductState;

            if(ProductState != null)
            {
                this.ProductStateId = ProductState.ProductStateId;
            }
            else
            {
                this.ProductStateId = 0;
            }
            
        }

        #region Properties

        [DataMember(Name = "productId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        #endregion

        #region Foreing keys

        [DataMember(Name = "warehouse")]
        public Warehouse Warehouse { get; set; }

        [DataMember(Name = "productState")]
        public ProductState ProductState { get; set; }

        #endregion
    }
}
