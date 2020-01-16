using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplier_Entities.EntityModel
{
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public int WarehouseId { get; set; }

        public int ProductStateId { get; set; }

        [MaxLength(100)]
        public string ProductDescription { get; set; }

        public double Prize { get; set; }

        public int Cuantity { get; set; }

        #endregion

        #region Foreing keys

        public Warehouse Warehouse { get; set; }

        public ProductState ProductState { get; set; }

        #endregion
    }
}
