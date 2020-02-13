using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Helper.Authentication
{
    public interface IAuthenticationProvider
    {
        bool CheckAuthentication(HttpRequestHeaders headers);
    }
}
