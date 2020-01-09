using Sale_Entities.EntityModel;
using System.Data.Entity;

namespace Sale_Data.Context
{
    public sealed class SaleContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<TransportCompany> TransportCompany { get; set; }

    }
}