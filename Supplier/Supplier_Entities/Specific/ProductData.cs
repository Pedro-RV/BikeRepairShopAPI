using System.Runtime.Serialization;

namespace Supplier_Entities.Specific
{
    [DataContract]
    public partial class ProductData
    {
        public ProductData()
        {

        }

        public ProductData(int ProductId, string ProductName, string ProductStateName)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.ProductStateName = ProductStateName;
        }

        [DataMember(Name = "productId")]
        public int ProductId { get; set; }

        [DataMember(Name = "productDescription")]
        public string ProductName { get; set; }

        [DataMember(Name = "productStateDescription")]
        public string ProductStateName { get; set; }
    }
}
