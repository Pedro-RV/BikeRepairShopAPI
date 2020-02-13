using System.Net.Http.Headers;

namespace Supplier_Helper.Authentication
{
    public interface IAuthenticationProvider
    {
        bool CheckAuthentication(HttpRequestHeaders headers);
    }
}