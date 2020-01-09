using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sale_Entities.EntityModel
{
    [Table("PaymentMethod")]
    public class PaymentMethod
    {
        public PaymentMethod()
        {

        }

        public PaymentMethod(string PaymentMethodDescription)
        {
            this.PaymentMethodDescription = PaymentMethodDescription;
        }

        #region Properties

        public int PaymentMethodId { get; set; }

        [MaxLength(20)]
        public string PaymentMethodDescription { get; set; }

        #endregion
    }
}
