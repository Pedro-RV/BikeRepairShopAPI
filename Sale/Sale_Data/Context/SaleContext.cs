using Sale_Data.Interfaces;
using Sale_Entities.EntityModel;
using System.Data.Entity;

namespace Sale_Data.Context
{
    public class SaleContext : DbContext
    {
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }
        public virtual DbSet<TransportCompany> TransportCompany { get; set; }

    }
}