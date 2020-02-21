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

        public ProductSpecific(string ProductDescription, double Prize, int Cuantity, bool ActiveFlag, int ProductTypeId)
        {
            this.ProductDescription = ProductDescription;
            this.Prize = Prize;
            this.Cuantity = Cuantity;
            this.ActiveFlag = ActiveFlag;
            this.ProductTypeId = ProductTypeId;

        }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "productTypeId")]
        public int ProductTypeId { get; set; }

        [DataMember(Name = "productDescription")]
        [MaxLength(500)]
        public string ProductDescription { get; set; }

        [DataMember(Name = "prize")]
        public double Prize { get; set; }

        [DataMember(Name = "cuantity")]
        public int Cuantity { get; set; }

        [DataMember(Name = "activeFlag")]
        public bool ActiveFlag { get; set; }
    }
}
