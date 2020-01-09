using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using System.Data.Entity;

namespace Supplier_Data.Context
{
    public class SupplierContext : DbContext, ISupplierContext
    {
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductState> ProductState { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<SupplyCompany> SupplyCompany { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<WarehouseAdmin> WarehouseAdmin { get; set; }      

    }
}
