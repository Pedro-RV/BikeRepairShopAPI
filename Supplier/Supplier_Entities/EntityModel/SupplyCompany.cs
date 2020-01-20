using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Supplier_Entities.EntityModel
{
    [DataContract]
    [Table("SupplyCompany")]
    public class SupplyCompany
    {
        public SupplyCompany()
        {

        }

        public SupplyCompany(string SupplyCompanyName, string TelephoneNum)
        {
            this.SupplyCompanyName = SupplyCompanyName;
            this.TelephoneNum = TelephoneNum;
        }

        #region Properties

        [DataMember(Name = "supplyCompanyId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplyCompanyId { get; set; }

        [DataMember(Name = "supplyCompanyName")]
        [MaxLength(100)]
        public string SupplyCompanyName { get; set; }

        [DataMember(Name = "telephoneNum")]
        [MaxLength(15)]
        public string TelephoneNum { get; set; }

        #endregion
    }
}
