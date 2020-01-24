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
    public class ProductStateSpecific
    {
        public ProductStateSpecific()
        {

        }

        public ProductStateSpecific(string ProductStateDescription)
        {
            this.ProductStateDescription = ProductStateDescription;
        }

        [DataMember(Name = "productStateId")]
        public int ProductStateId { get; set; }

        [DataMember(Name = "productStateDescription")]
        [MaxLength(100)]
        public string ProductStateDescription { get; set; }
    }
}
