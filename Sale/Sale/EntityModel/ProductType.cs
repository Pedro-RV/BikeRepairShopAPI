using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sale_Entities.EntityModel
{
    [Table("ProductType")]
    public class ProductType
    {
        public ProductType()
        {

        }

        public ProductType(string ProductTypeDescription)
        {
            this.ProductTypeDescription = ProductTypeDescription;
        }

        #region Properties

        public int ProductTypeId { get; set; }

        [MaxLength(50)]
        public string ProductTypeDescription { get; set; }

        #endregion
    }
}
