using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sale_Entities.EntityModel
{
    [Table("TransportCompany")]
    public class TransportCompany
    {
        public TransportCompany()
        {

        }

        public TransportCompany(string TransportCompanyName, string TelephoneNum)
        {
            this.TransportCompanyName = TransportCompanyName;
            this.TelephoneNum = TelephoneNum;
        }

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransportCompanyId { get; set; }

        [MaxLength(100)]
        public string TransportCompanyName { get; set; }

        [MaxLength(15)]
        public string TelephoneNum { get; set; }

        #endregion
    }
}
