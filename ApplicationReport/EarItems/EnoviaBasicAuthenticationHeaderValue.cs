using System.Net.Http.Headers;
using Csoft.EnoviaAtmIntegration.Domain.Credentials;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// encapsulates Basic scheme and credentials
    /// </summary>
    public class EnoviaBasicAuthenticationHeaderValue : AuthenticationHeaderValue {
        public EnoviaBasicAuthenticationHeaderValue() : base(
            "Basic", new DefaultCredentials().ToString()) { }
    }
}