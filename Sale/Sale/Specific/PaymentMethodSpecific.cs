using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Entities.Specific
{
    [DataContract]
    public class PaymentMethodSpecific
    {
        public PaymentMethodSpecific()
        {

        }

        public PaymentMethodSpecific(string PaymentMethodDescription)
        {
            this.PaymentMethodDescription = PaymentMethodDescription;
        }

        [DataMember(Name = "paymentMethodId")]
        public int PaymentMethodId { get; set; }

        [DataMember(Name = "paymentMethodDescription")]
        [MaxLength(70)]
        public string PaymentMethodDescription { get; set; }
    }
}
