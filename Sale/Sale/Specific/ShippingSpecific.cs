using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Entities.Specific
{
    [DataContract]
    public class ShippingSpecific
    {
        public ShippingSpecific()
        {

        }

        public ShippingSpecific(DateTime DepartureDate, DateTime PackingTime, int SaleId, int TransportCompanyId)
        {
            this.DepartureDate = DepartureDate;
            this.PackingTime = PackingTime;
            this.SaleId = SaleId;
            this.TransportCompanyId = TransportCompanyId;

        }

        [DataMember(Name = "shippingId")]
        public int ShippingId { get; set; }

        [DataMember(Name = "saleId")]
        public int SaleId { get; set; }

        [DataMember(Name = "transportCompanyId")]
        public int TransportCompanyId { get; set; }

        [DataMember(Name = "departureDate")]
        public DateTime DepartureDate { get; set; }

        [DataMember(Name = "packingTime")]
        public DateTime PackingTime { get; set; }

    }
}
