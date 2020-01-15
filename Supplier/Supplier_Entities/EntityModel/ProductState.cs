using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplier_Entities.EntityModel
{
    [Table("ProductState")]
    public class ProductState
    {
        public ProductState()
        {

        }

        public ProductState(string ProductStateDescription)
        {
            this.ProductStateDescription = ProductStateDescription;
        }

        #region Properties

        public int ProductStateId { get; set; }

        [MaxLength(100)]
        public string ProductStateDescription { get; set; }

        #endregion

    }
}
