using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Entities.EntityModel
{
    [Table("Bill")]
    public class Bill
    {
        public Bill()
        {

        }

        public Bill(DateTime BillDate, PaymentMethod PaymentMethod)
        {
            this.BillDate = BillDate;
            this.PaymentMethod = PaymentMethod;

            if(PaymentMethod != null)
            {
                this.PaymentMethodId = PaymentMethod.PaymentMethodId;
            }
            else
            {
                this.PaymentMethodId = 0;
            }

        }

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }

        public int PaymentMethodId { get; set; }

        public DateTime BillDate { get; set; }

        #endregion

        #region Foreing keys

        public PaymentMethod PaymentMethod { get; set; }

        #endregion

    }
}
