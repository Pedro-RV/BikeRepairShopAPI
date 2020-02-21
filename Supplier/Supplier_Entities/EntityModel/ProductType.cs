using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Supplier_Entities.EntityModel
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductTypeId { get; set; }

        [MaxLength(100)]
        public string ProductTypeDescription { get; set; }       

        #endregion

    }
}
