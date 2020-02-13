using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Helper.Authentication
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        public virtual bool CheckAuthentication(HttpRequestHeaders headers)
        {
            string userAuthentication = null, pwdAuthentication = null;
            bool result = false;

            if (headers.Contains("userAuthentication"))
            {
                userAuthentication = headers.GetValues("userAuthentication").First();
            }

            if (headers.Contains("pwdAuthentication"))
            {
                pwdAuthentication = headers.GetValues("pwdAuthentication").First();
            }

            if (userAuthentication == "pedro" && pwdAuthentication == "0123")
            {
                result = true;
            }

            return result;
        }
    }
}
