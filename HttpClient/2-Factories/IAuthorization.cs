using System.Net.Http.Headers;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public interface IAuthorization {
        AuthenticationHeaderValue CreateAuthorization();
    }
}