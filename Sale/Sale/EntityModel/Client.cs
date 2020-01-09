using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sale_Entities.EntityModel
{
    [Table("Client")]
    public class Client
    {
        public Client()
        {

        }

        public Client(string ClientName, string Surname, string DNI, string Email, string ClientAddress, string CP, string MobileNum)
        {
            this.ClientName = ClientName;
            this.Surname = Surname;
            this.DNI = DNI;
            this.Email = Email;
            this.ClientAddress = ClientAddress;
            this.CP = CP;
            this.MobileNum = MobileNum;
        }

        #region Properties

        public int ClientId { get; set; }

        [MaxLength(20)]
        public string ClientName { get; set; }

        [MaxLength(30)]
        public string Surname { get; set; }

        [MaxLength(15)]
        public string DNI { get; set; }

        [MaxLength(20)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string ClientAddress { get; set; }

        [MaxLength(10)]
        public string CP { get; set; }

        [MaxLength(15)]
        public string MobileNum { get; set; }

        #endregion
    }
}
