using System.Net.Http;
using Csoft.EnoviaAtmIntegration.Domain.Http;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// fetches json from Enovia
    /// </summary>
    internal class EcasJson : JsonDispatch {
        internal protected override HttpRequestMessage HttpRequestMessage { get; } =
            new PostHttpRequestMessage(
                new AllEcaRequestFactory()
            );
    }
}