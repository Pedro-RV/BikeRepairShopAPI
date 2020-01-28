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
    public class TransportCompanySpecific
    {
        public TransportCompanySpecific()
        {

        }

        public TransportCompanySpecific(string TransportCompanyName, string TelephoneNum)
        {
            this.TransportCompanyName = TransportCompanyName;
            this.TelephoneNum = TelephoneNum;

        }

        [DataMember(Name = "transportCompanyId")]
        public int TransportCompanyId { get; set; }

        [DataMember(Name = "transportCompanyName")]
        [MaxLength(100)]
        public string TransportCompanyName { get; set; }

        [DataMember(Name = "telephoneNum")]
        [MaxLength(15)]
        public string TelephoneNum { get; set; }
    }
}
