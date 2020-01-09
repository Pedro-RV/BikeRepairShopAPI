using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sale_Entities.EntityModel
{
    [Table("Shipping")]
    public class Shipping
    {
        public Shipping()
        {

        }

        public Shipping(DateTime DepartureDate, DateTime PackingTime, Sale Sale, TransportCompany TransportCompany)
        {
            this.DepartureDate = DepartureDate;
            this.PackingTime = PackingTime;
            this.Sale = Sale;
            this.SaleId = Sale.SaleId;
            this.TransportCompany = TransportCompany;
            this.TransportCompanyId = TransportCompany.TransportCompanyId;
        }

        #region Properties

        public int ShippingId { get; set; }

        public int SaleId { get; set; }

        public int TransportCompanyId { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime PackingTime { get; set; }

        #endregion

        #region Foreing keys

        public Sale Sale { get; set; }

        public TransportCompany TransportCompany { get; set; }

        #endregion
    }
}
