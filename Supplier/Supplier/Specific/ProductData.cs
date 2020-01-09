namespace Supplier_Entities.Specific
{
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

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductStateName { get; set; }
    }
}
