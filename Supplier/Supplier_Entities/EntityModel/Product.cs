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

        public Product(String ProductDescription, double Prize, int Cuantity, bool ActiveFlag)
        {
            this.ProductDescription = ProductDescription;
            this.Prize = Prize;
            this.Cuantity = Cuantity;
            this.ActiveFlag = ActiveFlag;

        }

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public int WarehouseId { get; set; }

        public int ProductStateId { get; set; }

        [MaxLength(500)]
        public string ProductDescription { get; set; }

        public double Prize { get; set; }

        public int Cuantity { get; set; }

        public bool ActiveFlag { get; set; }

        #endregion

    }
}
