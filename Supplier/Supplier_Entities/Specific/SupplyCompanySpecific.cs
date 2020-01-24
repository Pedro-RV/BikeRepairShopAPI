using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Entities.Specific
{
    [DataContract]
    public class SupplyCompanySpecific
    {
        public SupplyCompanySpecific()
        {

        }

        public SupplyCompanySpecific(string SupplyCompanyName, string TelephoneNum)
        {
            this.SupplyCompanyName = SupplyCompanyName;
            this.TelephoneNum = TelephoneNum;
        }

        [DataMember(Name = "supplyCompanyId")]
        public int SupplyCompanyId { get; set; }

        [DataMember(Name = "supplyCompanyName")]
        [MaxLength(100)]
        public string SupplyCompanyName { get; set; }

        [DataMember(Name = "telephoneNum")]
        [MaxLength(15)]
        public string TelephoneNum { get; set; }
    }
}
