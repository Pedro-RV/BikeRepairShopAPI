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
    public class ClientSpecific
    {
        public ClientSpecific()
        {

        }

        public ClientSpecific(string ClientName, string Surname, string DNI, string Email, string ClientAddress, string CP, string MobileNum)
        {
            this.ClientName = ClientName;
            this.Surname = Surname;
            this.DNI = DNI;
            this.Email = Email;
            this.ClientAddress = ClientAddress;
            this.CP = CP;
            this.MobileNum = MobileNum;
        }

        [DataMember(Name = "clientId")]
        public int ClientId { get; set; }

        [DataMember(Name = "clientName")]
        [MaxLength(20)]
        public string ClientName { get; set; }

        [DataMember(Name = "surname")]
        [MaxLength(30)]
        public string Surname { get; set; }

        [DataMember(Name = "dni")]
        [MaxLength(15)]
        public string DNI { get; set; }

        [DataMember(Name = "email")]
        [MaxLength(20)]
        public string Email { get; set; }

        [DataMember(Name = "clientAddress")]
        [MaxLength(100)]
        public string ClientAddress { get; set; }

        [DataMember(Name = "cp")]
        [MaxLength(10)]
        public string CP { get; set; }

        [DataMember(Name = "mobileNum")]
        [MaxLength(15)]
        public string MobileNum { get; set; }

    }
}
