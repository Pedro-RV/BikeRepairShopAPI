using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Entities.EntityModel
{ 
    [Table("ProductInfo")]
    public class ProductInfo
    {
        public ProductInfo()
        {

        }

        public ProductInfo(Product Product, Warehouse Warehouse, ProductState ProductState)
        {
            this.Product = Product;

            if(Product != null)
            {
                this.ProductId = Product.ProductId;
            }
            else
            {
                this.ProductId = 0;
            }

            this.Warehouse = Warehouse;

            if (Warehouse != null)
            {
                this.WarehouseId = Warehouse.WarehouseId;
            }
            else
            {
                this.WarehouseId = 0;
            }

            this.ProductState = ProductState;

            if (ProductState != null)
            {
                this.ProductStateId = ProductState.ProductStateId;
            }
            else
            {
                this.ProductStateId = 0;
            }

        }

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductInfoId { get; set; }

        public int ProductId { get; set; }

        public int WarehouseId { get; set; }

        public int ProductStateId { get; set; }

        #endregion

        #region Foreing keys

        public Product Product { get; set; }

        public Warehouse Warehouse { get; set; }

        public ProductState ProductState { get; set; }

        #endregion



    }
}
