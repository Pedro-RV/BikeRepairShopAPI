using Supplier_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Data.Interfaces
{
    public interface ISupplierContext
    {
        DbSet<Employee> Employee { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<ProductState> ProductState { get; set; }
        DbSet<Purchase> Purchase { get; set; }
        DbSet<SupplyCompany> SupplyCompany { get; set; }
        DbSet<Warehouse> Warehouse { get; set; }
        DbSet<WarehouseAdmin> WarehouseAdmin { get; set; }
    }
}
