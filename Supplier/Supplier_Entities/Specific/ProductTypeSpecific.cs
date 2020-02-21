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
    public class ProductTypeSpecific
    {
        public ProductTypeSpecific()
        {

        }

        public ProductTypeSpecific(string ProductTypeDescription)
        {
            this.ProductTypeDescription = ProductTypeDescription;
        }

        [DataMember(Name = "productTypeId")]
        public int ProductTypeId { get; set; }

        [DataMember(Name = "productTypeDescription")]
        [MaxLength(100)]
        public string ProductTypeDescription { get; set; }
    }
}
