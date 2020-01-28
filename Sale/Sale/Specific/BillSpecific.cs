using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Entities.Specific
{
    [DataContract]
    public class BillSpecific
    {
        public BillSpecific()
        {

        }

        public BillSpecific(DateTime BillDate, int PaymentMethodId)
        {
            this.BillDate = BillDate;
            this.PaymentMethodId = PaymentMethodId;

        }

        [DataMember(Name = "billId")]
        public int BillId { get; set; }

        [DataMember(Name = "paymentMethodId")]
        public int PaymentMethodId { get; set; }

        [DataMember(Name = "billDate")]
        public DateTime BillDate { get; set; }
    }
}
