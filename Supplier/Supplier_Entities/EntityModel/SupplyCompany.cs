using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplier_Entities.EntityModel
{
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

        public int SupplyCompanyId { get; set; }

        [MaxLength(30)]
        public string SupplyCompanyName { get; set; }

        [MaxLength(15)]
        public string TelephoneNum { get; set; }

        #endregion
    }
}
