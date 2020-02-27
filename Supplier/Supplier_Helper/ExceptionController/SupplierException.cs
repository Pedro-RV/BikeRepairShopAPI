using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Supplier_Helper.ExceptionController
{
    [Serializable]
    public class SupplierException : Exception
    {
        private readonly string errorCode;

        public SupplierException()
        {

        }

        public SupplierException(string message)
            : base(message)
        {

        }

        public SupplierException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SupplierException(string message, string errorCode)
            : base(message)
        {
            this.errorCode = errorCode;
        }

        public SupplierException(string message, string errorCode, Exception innerException)
            : base(message, innerException)
        {
            this.errorCode = errorCode;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected SupplierException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.errorCode = info.GetString("ErrorCode");
        }

        public string ErrorCode
        {
            get { return this.errorCode; }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("ErrorCode", this.ErrorCode);

            // MUST call through to the base class to let it save its own state
            base.GetObjectData(info, context);
        }

    }
}
