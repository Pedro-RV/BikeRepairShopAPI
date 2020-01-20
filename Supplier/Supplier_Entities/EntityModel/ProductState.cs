using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Supplier_Entities.EntityModel
{
    [DataContract]
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

        [DataMember(Name = "productStateId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductStateId { get; set; }

        [DataMember(Name = "productStateDescription")]
        [MaxLength(100)]
        public string ProductStateDescription { get; set; }

        #endregion

    }
}
