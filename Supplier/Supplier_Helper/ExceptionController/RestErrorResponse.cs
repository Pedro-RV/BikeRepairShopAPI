using System.Runtime.Serialization;

namespace Supplier_Helper.ExceptionController
{
    [DataContract]
    public class RestErrorResponse
    {
        [DataMember]
        public SupplierException SupplierException { get; set; }

        [DataMember]
        public string ErroMessage { get; set; }

        [DataMember]
        public string ErroCode { get; set; }

        public RestErrorResponse()
        { 
            
        }

        public RestErrorResponse(string errorMessage, string errorCode)
        {
            this.ErroMessage = errorMessage;
            this.ErroCode = errorCode;
        }

        public RestErrorResponse(SupplierException supplierException, string errorMessage, string errorCode)
        {
            this.SupplierException = supplierException;
            this.ErroMessage = errorMessage;
            this.ErroCode = errorCode;
        }
    }
}