using Sale_Entities.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Data.Interfaces
{
    public interface ISaleContext
    {
        DbSet<Bill> Bill { get; set; }
        DbSet<Client> Client { get; set; }
        DbSet<PaymentMethod> PaymentMethod { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<ProductType> ProductType { get; set; }
        DbSet<Sale> Sale { get; set; }
        DbSet<Shipping> Shipping { get; set; }
        DbSet<TransportCompany> TransportCompany { get; set; }
    }
}
